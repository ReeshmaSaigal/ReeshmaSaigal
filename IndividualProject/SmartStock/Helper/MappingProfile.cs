using Domain.Modules.Auth.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SmartStock.API.User.RequestObject;
using Domain.Modules.User.DTO;
using Domain.Models;
using Domain.Modules.Products.DTO;
using SmartStock.API.Products.RequestObject;
using Domain.Modules.Categories.DTO;
using SmartStock.API.Category.RequestObject;
using Domain.Modules.Suppliers.DTO;
using SmartStock.API.Suppliers.RequestObject;
using Domain.Modules.Stocks.DTO;
using SmartStock.API.Stocks.RequestObjects;
using Domain.Modules.Purchases.DTO;
using SmartStock.API.Purchases.RequestObject;
using Domain.Modules.Sales.DTO;
using SmartStock.API.Sales.RequestObject;

namespace SmartStock.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<AppUser, AuthResponseDto>().ReverseMap();
            CreateMap<AppUser,CreateUserDto>().ReverseMap();
            CreateMap<AppUser, UserResponseDto>().ReverseMap();
            CreateMap <UpdateUserDto,UpdateUserRequest>().ReverseMap();
            CreateMap<CreateUserDto, CreateUserRequest>().ReverseMap();
            CreateMap<UserResponseDto,UserResponse>().ReverseMap();

            //Product
            CreateMap<Product, ProductResponseDto>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();

            CreateMap<CreateProductRequest, CreateProductDto>().ReverseMap();
            CreateMap<UpdateProductRequest, UpdateProductDto>().ReverseMap();

            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();


            //Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            CreateMap<CreateCategoryRequest, CreateCategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryRequest, UpdateCategoryDto>().ReverseMap();

            //Supplier

            CreateMap<SupplierDto,Supplier>().ReverseMap();
            CreateMap<CreateSupplierDto, Supplier>().ReverseMap();
            CreateMap<UpdateSupplierDto, Supplier>().ReverseMap();
            CreateMap<CreateSupplierRequest, CreateSupplierDto>().ReverseMap();
            CreateMap<UpdateSupplierRequest, UpdateSupplierDto>().ReverseMap();

            //Stock
            CreateMap<CreateStockRequest, CreateStockDto>();
            CreateMap<StockTransaction, StockResponseDto>();

            //Purchase
            CreateMap<CreatePurchaseRequest, Purchase>();
            CreateMap<CreatePurchaseRequest, PurchaseDto>();
            CreateMap<CreatePurchaseItemRequest, PurchaseItem>();

            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<PurchaseItem, PurchaseItemDto>().ReverseMap();

            //Sales
            CreateMap<CreateSaleRequest, Sale>();
            CreateMap<CreateSaleItemRequest, SaleItem>();

            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<SaleItem, SaleItemDto>().ReverseMap();

        }
    }
}
