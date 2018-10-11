﻿using MCGA.Data;
using MCGA.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace MCGA.Business
{
    public class AgendaComponent : ICrud<Agenda>
    {
        private MedicureContext db = new MedicureContext();
        public void Create(Agenda entity)
        {
            entity.createdon = DateTime.Now;
            db.Agenda.Add(entity);
            db.SaveChanges();
        }
        public void Delete(Agenda entity)
        {
            entity.deletedon = DateTime.Now;
            db.Agenda.Remove(entity);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IList<Agenda> Get()
        {
            var agenda = db.Agenda.Include(a => a.TipoDia);
            return agenda.ToList();
        }

        public Agenda GetDetail(int? id)
        {
            return db.Agenda.Find(id);
        }

        public void Update(Agenda entity)
        {
            entity.changedon = DateTime.Now;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
