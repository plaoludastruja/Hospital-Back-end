﻿using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using IntegrationLibrary.Tenders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tenders.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private readonly IntegrationDbContext _context;

        public TenderRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public void Create(Tender tender)
        {
            _context.Tenders.Add(tender);
            _context.SaveChanges();
        }

        public IEnumerable<Tender> GetAll()
        {
            return _context.Tenders.ToList();
        }
        public Tender GetById(Guid id) 
        {
            Tender tender = _context.Tenders.Find(id);
            if (tender == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return tender;
            }
        }
    }
}