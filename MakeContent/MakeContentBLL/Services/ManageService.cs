using MakeContentCore.Context;
using MakeContentDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeContentBLL.Services
{
    public class ManageService
    {
        private readonly CreatorsContext _context;
        public ManageService(CreatorsContext context)
        {
            this._context = context;
        }

        
    }
}
