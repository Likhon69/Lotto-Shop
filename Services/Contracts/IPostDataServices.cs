using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IPostDataServices
    {
        bool PostData(ProductDto model);
        //ICollection<Shoe> GetShoeData();
    }
}
