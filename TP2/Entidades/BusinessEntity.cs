using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BusinessEntity
    {
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }

       
        public int ID { get; set; }
        public States State { get; set; }

        public BusinessEntity()
        {
            State = States.New;
        }

        

        
    }

}

