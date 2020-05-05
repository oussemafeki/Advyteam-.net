using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

using Data;
using ServicePattern;


namespace Service
{
    interface IProject : IService<project>
    {
    }
}
