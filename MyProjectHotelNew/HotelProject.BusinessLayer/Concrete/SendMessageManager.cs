using System;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;
        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }
        public void TDelete(SendMessage t)
        {
            _sendMessageDal.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
            return _sendMessageDal.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendMessageDal.GetList();
        }

        public async Task TInsertAsync(SendMessage t)
        {
            await _sendMessageDal.InsertAsync(t);
        }

        public async Task TUpdateAsync(SendMessage t)
        {
            await _sendMessageDal.UpdateAsync(t);
        }
    }
}

