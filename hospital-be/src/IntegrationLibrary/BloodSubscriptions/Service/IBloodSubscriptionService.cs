﻿using System;
using System.Collections.Generic;

namespace IntegrationLibrary.BloodSubscriptions.Service
{
    public interface IBloodSubscriptionService
    {
        public IEnumerable<BloodSubscription> GetAll();
        public BloodSubscription GetById(Guid id);
        public BloodSubscription Create(BloodSubscription subscription);
        public BloodSubscription Update(BloodSubscription subscription);
        public BloodSubscription GetByBbTitle(string title);
        public IEnumerable<BloodSubscription> GetActiveNotSent();
    }
}