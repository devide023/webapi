﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Api.Model;
namespace Api.Dao
{
    public partial  class Db : DbContext
    {
        public Db(string constr) : base(constr)
        {
        }

        public Db() : base("conn")
        {
        }
    }
}
