﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace MyAPI.ApiSecurity
{
    [ApiSecurity]
    public class BaseApiSecurity: ApiController
    {
    }
}
