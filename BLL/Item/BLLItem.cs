using InterviewTask.DAL.Category;
using InterviewTask.Models;

namespace InterviewTask.BLL.Item
{
    public class BLLItem
    {
        public static List<ItemDTO> Search()
        {
            try
            {
                DALItem dALItem = new DALItem();
                return dALItem.Search();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SaveItem(ItemDTO item)
        {
            try
            {
                DALItem dALItem = new DALItem();
                return dALItem.AddItem(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DeleteItem(int ID)
        {
            try
            {
                DALItem dALItem = new DALItem();
                return dALItem.Delete(ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ItemDTO GetItemByID(int ID)
        {
            try
            {
                DALItem dALItem = new DALItem();
                return dALItem.ItemGetByID(ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
