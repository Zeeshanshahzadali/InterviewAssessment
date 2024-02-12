using InterviewTask.DAL.Category;
using InterviewTask.Models;

namespace InterviewTask.BLL.Category
{
    public class BLLCategory
    {
        public static List<ItemCategoryDTO> Search()
        {
            try
            {
                DALCategory dALCategory = new DALCategory();
                return dALCategory.Search();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SaveCategory(ItemCategoryDTO itemCategoryDTO)
        {
            try
            {
                DALCategory dALitemCategory = new DALCategory();
                return dALitemCategory.AddItemCategory(itemCategoryDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DeleteCategory(int ID)
        {
            try
            {
                DALCategory dALCategory = new DALCategory();
                return dALCategory.Delete(ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
