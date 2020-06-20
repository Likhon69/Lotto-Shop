using AutoMapper;
using CommonUnitOfWork;
using Repository.Contracts;
using Services.Contracts;
using ShopModels.Models;
using ShopModels.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementation
{
    public class PostDataServices : IPostDataServices
    {
        private IUnitOfWork _unitOfWork;
        private IShoePost _shoePost;
        private readonly IMapper _mapper;

        public PostDataServices(IUnitOfWork unitOfWork, IShoePost shoePost, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _shoePost = shoePost;
            _mapper = mapper;
        }

        public bool PostData(ProductDto model)
        {
            var product = _mapper.Map<User>(model);

            string finalImage = "";
            int pos = 12;
            if (pos >= 0)
            {
                // String after founder  
                string afterFounder = model.ProductImage.Remove(pos);
              
                // Remove everything before founder but include founder  
                string beforeFounder = model.ProductImage.Remove(0, pos);
                finalImage = beforeFounder;


            }


           
          /*      product.ProductImage = finalImage;
            _unitOfWork.Shoe.Save(product);
             _unitOfWork.Commit();*/
            return true;
           
        }

      /*  public ICollection<Shoe> GetShoeData()
        {
            var data = _shoePost.GetAll().ToList();
            return data;
        }*/
    }
}
