using InterviewTask.Models;
using System.Data;
using System.Data.Common;

namespace InterviewTask.DAL.Category
{
    public class DALItem : DALBase
    {
        #region "Constant"
        private const string Search_Item = "GetAllItems";
        private const string Add_Item = "AddItem";
        private const string Item_Delete = "DeleteItemById";
        private const string GetItemByID = "GetItemById";

        #endregion

        #region "Parameters"
        private const string ID = "ID";
        private const string Name = "ItemName";
        private const string DESCRIPTION = "Description";
        private const string VARIATIONNAME = "VariationName";
        private const string PRICE = "Price";
        private const string CATEGORYID = "CategoryID";
        private const string DELIVERYPRICE = "DeliveryPrice";
        private const string PICKUPPRICE = "PickUpPrice";
        private const string DINEINPRICE = "DineInPrice";
        private const string IMAGE = "Image";
        // here is the parameter that can match the table fields.
        #endregion

        #region "Function"
        private ItemDTO FillDTO(IDataReader reader)
        {
            ItemDTO item = new ItemDTO();
            item.ID = Common.Conversion.ToInt(reader[ID]);
            item.Name = Common.Conversion.ToString(reader[Name]);
            item.Description = Common.Conversion.ToString(reader[DESCRIPTION]);
            item.VariationName = Common.Conversion.ToString(reader[VARIATIONNAME]);
            item.Price = Common.Conversion.ToInt(reader[PRICE]);
            item.CategoryID = Common.Conversion.ToInt(reader[CATEGORYID]);
            item.DeliveryPrice = Common.Conversion.ToInt(reader[DELIVERYPRICE]);
            item.PickUpPrice = Common.Conversion.ToInt(reader[PICKUPPRICE]);
            item.DineInPrice = Common.Conversion.ToInt(reader[DINEINPRICE]);
            item.Image = Common.Conversion.ToString(reader[IMAGE]);
            return item;

        }

        public List<ItemDTO> Search()
        {
            IDataReader reader = null;
            try
            {
                List<ItemDTO> ItemDto = new List<ItemDTO>();
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(Search_Item))
                {
                    //this.SqlDatabase.AddInParameter(dbcmd, Name, SqlDbType.NVarChar, null);
                    reader = this.SqlDatabase.ExecuteReader(dbcmd);
                    while (reader.Read())
                    {
                        ItemDto.Add(FillDTO(reader));
                    }
                    return ItemDto;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ItemDTO ItemGetByID(int id)
        {
            IDataReader reader = null;
            try
            {
                ItemDTO ItemDto = new ItemDTO();
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(GetItemByID))
                {
                    this.SqlDatabase.AddInParameter(dbcmd, ID, SqlDbType.Int, id);
                    reader = this.SqlDatabase.ExecuteReader(dbcmd);
                    while (reader.Read())
                    {
                        ItemDto = FillDTO(reader);
                    }
                    return ItemDto;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string AddItem(ItemDTO item)
        {
            try
            {
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(Add_Item))
                {
                    //SqlDatabase.AddInParameter(dbcmd, ID, SqlDbType.Int, item.ID);
                    SqlDatabase.AddInParameter(dbcmd, Name, SqlDbType.NVarChar, item.Name);
                    SqlDatabase.AddInParameter(dbcmd, DESCRIPTION, SqlDbType.NVarChar, item.Description);
                    SqlDatabase.AddInParameter(dbcmd, VARIATIONNAME, SqlDbType.NVarChar, item.VariationName);
                    SqlDatabase.AddInParameter(dbcmd, PRICE, SqlDbType.Int, item.Price);
                    SqlDatabase.AddInParameter(dbcmd, CATEGORYID, SqlDbType.Int, item.CategoryID);
                    SqlDatabase.AddInParameter(dbcmd, DELIVERYPRICE, SqlDbType.Int, item.DeliveryPrice);
                    SqlDatabase.AddInParameter(dbcmd, PICKUPPRICE, SqlDbType.Int, item.PickUpPrice);
                    SqlDatabase.AddInParameter(dbcmd, DINEINPRICE, SqlDbType.Int, item.DineInPrice);
                    SqlDatabase.AddInParameter(dbcmd, IMAGE, SqlDbType.NVarChar, item.Image);
                    SqlDatabase.ExecuteNonQuery(dbcmd);

                    return "New Item entity is created.";
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
                using (DbCommand dbcmd = this.SqlDatabase.GetStoredProcCommand(Item_Delete))
                {
                    this.SqlDatabase.AddInParameter(dbcmd, ID, SqlDbType.BigInt, id);
                    this.SqlDatabase.ExecuteNonQuery(dbcmd);
                    return "Item Successfully Deleted.";
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
