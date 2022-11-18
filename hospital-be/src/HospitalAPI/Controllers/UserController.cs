﻿using AutoMapper;
using HospitalAPI.Dtos.Auth;
using HospitalAPI.Dtos.User;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Net.Mail;
using System.Net;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IAddressService addressService,
            IPatientService patientService, IMapper mapper, IJwtService jwtService)
        {
            _userService = userService;
            _patientService = patientService;
            _mapper = mapper;
        }

        //POST api/user/registerPatient
        [HttpPost]
        [Route("[action]")]
        public ActionResult RegisterPatient([FromBody] PatientRegistrationDto registrationDto)
        {
            try
            {
                var address = _mapper.Map<Address>(registrationDto.AddressRequestDto);
                var patient = _mapper.Map<Patient>(registrationDto);
                var user = _mapper.Map<User>(registrationDto.UserLoginDto);

                patient.Address = address;
                patient.AddressId = address.Id;
                _patientService.RegisterPatient(patient, registrationDto.ChoosenDoctorId,
                    registrationDto.AllergieIds);

                user = _userService.RegisterPatient(user, patient.Id);
                //slanje maila (pozivanje servia koji salje mail)
                _userService.SendVerificationLinkEmail(user);

                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //POST api/user/loginUser/patient
        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult LoginPatient([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var token = _userService.AuthenticatePatient(userLogin.Username, userLogin.Password);
                return Ok(new JwtDto(token));
            }
            catch (NotFoundException)
            {
                return NotFound("User not found");
            }
            catch (BadPasswordException)
            {
                return Unauthorized("Bad password");
            }
            catch (UnauthorizedException)
            {
                return Unauthorized("Only patients can login from public app");
            }
        }

        //TODO slucaj kada vise puta osvezim stranicu
        [HttpPost]
        [Route("[action]")]
        public ActionResult ActivateAccount([FromBody] AccountActivationDto activationInformation)
        {
            if (activationInformation == null)
            {
                return BadRequest();
            }

            var patient = _patientService.GetById(activationInformation.Id);
            
            if (patient == null)
            {
                return NotFound("User not found");
            }

            var user = _userService.GetAll().FirstOrDefault(r => r.PersonId == patient.Id);

            if (user.VerificationToken == System.Guid.Empty)
            {
                return BadRequest("Your account has already been activated");
            }

            if (activationInformation.Token == user.VerificationToken)
            {
                user.IsAccountActive = true;
                user.VerificationToken = System.Guid.Empty;
                _userService.Update(user);
                return Ok();
            }

            return Unauthorized("Tokens do not match");
        }
    }
}
