using InterviewTask.Models;
using System.Data;
using System.Data.Common;

namespace InterviewTask.DAL.Category
{
    public class DALCategory : DALBase
    {
        #region "Constant"
        private const string Search_Categoies = "GetCategories";
        private const string Add_Category = "AddCategory";
        private const string Category_Delete = "Delete_Category";
        #endregion

        #region "Parameters"
        private const string ID = "ID";
        private const string Name = "Name";
        // here is the parameter that can match the table fields.
        #endregion

        #region "Function"
        private ItemCategoryDTO FillDTO(IDataReader reader)
        {
            ItemCategoryDTO itemCategoryDTO = new ItemCategoryDTO();

            itemCategoryDTO.ID = Common.Conversion.ToInt(reader[ID]);
            itemCategoryDTO.Name = Common.Conversion.ToString(reader[Name]);
            return itemCategoryDTO;

        }

        public List<ItemCategoryDTO> Search()
        {
            IDataReader reader = null;
            try
            {
                List<ItemCategoryDTO> CategoryDto = new List<ItemCategoryDTO>();
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(Search_Categoies))
                {
                    //this.SqlDatabase.AddInParameter(dbcmd, Name, SqlDbType.NVarChar, null);
                    reader = this.SqlDatabase.ExecuteReader(dbcmd);
                    while (reader.Read())
                    {
                        CategoryDto.Add(FillDTO(reader));
                    }
                    return CategoryDto;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string AddItemCategory(ItemCategoryDTO itemCategoryDTO)
        {
            try
            {
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(Add_Category))
                {
                    SqlDatabase.AddInParameter(dbcmd, ID, SqlDbType.Int, itemCategoryDTO.ID);
                    SqlDatabase.AddInParameter(dbcmd, Name, SqlDbType.NVarChar, itemCategoryDTO.Name);
                    SqlDatabase.ExecuteNonQuery(dbcmd);

                    return "New Category entity is created.";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string Delete(int id)
        {
            IDataReader reader = null;
            try
            {
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(Category_Delete))
                {
                    this.SqlDatabase.AddInParameter(dbcmd, ID, SqlDbType.BigInt, id);
                    this.SqlDatabase.ExecuteNonQuery(dbcmd);
                    return "Category Successfully Deleted.";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (reader != null)
                {
                    if (reader.IsClosed == false)
                    {
                        reader.Close();
                    }
                }
            }
        }


        #endregion

    }
}
