using Repository.Contracts;
using ShopModels.ViewModel;
using System;
using Repository.Base;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Repository.Implementation
{
    public class PostArticleImageRepository : IPostArticleImageRepository
    {
        public int PostEArticleImage(ArticleImageVm model)
        {
            try
            {
                string connection = Constants.Connection;
                int i = 0;
                using (SqlConnection sqlConn = new SqlConnection(connection))
                {

                    if (sqlConn.State == 0)
                    {
                        sqlConn.Open();
                    }
                    using (SqlCommand sqlComm = new SqlCommand("USP_IMG_INSERT", sqlConn))
                    {
                        string finalImage = "";
                        int pos = 12;
                        if (pos != 0)
                        {
                            // String after founder  
                            string afterFounder = model.articleImage.Remove(pos);

                            // Remove everything before founder but include founder  
                            string beforeFounder = model.articleImage.Remove(0, pos);
                            finalImage = beforeFounder;

                        }

                        model.articleImage = finalImage;

                        sqlComm.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlComm.Parameters.AddWithValue("@PArtCode", model.art_Code);
                        sqlComm.Parameters.AddWithValue("@ImgName", model.articleImage);
                        sqlComm.Parameters.AddWithValue("@IsDefault", model.isDefault);
                        sqlComm.Parameters.AddWithValue("@CreatedBy", model.userId);
                        
                        
                      i =  sqlComm.ExecuteNonQuery();


                        sqlConn.Close();
                        return i;
                       

                    }

                  
                }

               

            
            
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
              

            }
        }
    }

