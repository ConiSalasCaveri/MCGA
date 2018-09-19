﻿using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCGA.UI.Process
{
    public class ProfesionalProcess : ICrud<Profesional>
    {
        private ProfesionalComponent component = new ProfesionalComponent();
        public void Create(Profesional entity)
        {
            component.Create(entity);
        }

        public void Delete(Profesional entity)
        {
            component.Delete(entity);
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Profesional> Get()
        {
            return component.Get();
        }

        public Profesional GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(Profesional entity)
        {
            component.Update(entity);
        }
    }
}
