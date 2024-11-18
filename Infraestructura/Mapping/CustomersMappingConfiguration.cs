using Core.DTOs.Customer;
using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class CustomersMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.BirthDate, src => src.BirthDate.ToShortDateString())
            .Map(dest => dest.Accounts, src => src.Accounts.Select(x => x.Adapt<DetailedCustomerDTO>()));

        //config.NewConfig < Account, DetailedCustomerDTO>()
        //    .Map(dest => dest.Id, src => src.Id)
        //    .Map(dest => dest.Number, src => src.Number)
        //    .Map(dest => dest.Balance, src => src.Balance)
        //    .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString());

        config.NewConfig<UpdateCustomerDTO, Customer>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.BirthDate, src => src.BirthDate);

        // config.NewConfig<CreateCustomerDTO, Customer>()
        //    .Map(dest => dest.FirstName, src => src.FirstName);

        // config.NewConfig<CreateEntityDTO, Customer>()
        //    .Map(dest => dest.Id, src => src.CustomerId);

        // CreateEntityDTO a Product
        config.NewConfig<CreateEntityDTO, Product>()
            .Map(dest => dest.ProductName, src => src.Product.ProductName)
            .Map(dest => dest.Status, src => "active")
            .Map(dest => dest.ProductDescription, src => src.Product.ProductDescription)
            .Map(dest => dest.StartDate, src => DateTime.UtcNow);

        // CreateEntityDTO a Entity
        config.NewConfig<CreateEntityDTO, Entity>()
            .Map(dest => dest.EntityName, src => src.EntityName);

        // 
        config.NewConfig<EntityCustomer, ClientEntityDTO>()
            .Map(dest => dest.EntityName, src => src.Entity.EntityName)
            .Map(dest => dest.Products, src => src.Entity.Products
                .Select(p => p.Adapt<ProductDTO>()));

        // ResponseProductDTO
        config.NewConfig<Product, ResponseProductDTO>()
            .Map(dest => dest.ProductName, src => src.ProductName)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.ProductDescription, src => src.ProductDescription)
            .Map(dest => dest.StartDate, src => src.StartDate.ToShortDateString());
    }
}
