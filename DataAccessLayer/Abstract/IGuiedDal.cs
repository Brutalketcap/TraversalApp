using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGuiedDal: IGenericDal<Guide>
    {
        void ChangeToTureByGuid(int id);
        void ChangeToFalseByGuid(int id);
        

    }
}
