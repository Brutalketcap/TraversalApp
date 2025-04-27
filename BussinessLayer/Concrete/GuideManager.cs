using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuiedDal _guideDal;

        public GuideManager(IGuiedDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void TChangeToFalseByGuid(int id)
        {
             _guideDal.ChangeToFalseByGuid(id);
        }

        public void TChangeToTureByGuid(int id)
        {
            _guideDal.ChangeToTureByGuid(id);
        }

        public void TDelete(Guide t)
        {
            _guideDal.Delete(t);
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public void TUpdata(Guide t)
        {
            _guideDal.Update(t);
        }
    }
}
