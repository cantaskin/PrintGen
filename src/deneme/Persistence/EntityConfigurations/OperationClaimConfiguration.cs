using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.CustomizedImages.Constants;
using Application.Features.Prompts.Constants;
using Application.Features.PromptCategories.Constants;
using Application.Features.Addresses.Constants;
using Application.Features.Gifts.Constants;
using Application.Features.Layers.Constants;
using Application.Features.Orders.Constants;
using Application.Features.OrderItems.Constants;
using Application.Features.PackingSlips.Constants;
using Application.Features.Placements.Constants;
using Application.Features.Positions.Constants;
using Application.Features.RetailCosts.Constants;
using Application.Features.Customizations.Constants;
using Application.Features.Options.Constants;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Application.Features.TemplateProducts.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1612;

    public static int UserId => 2018;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;

            yield return new() { Id = UserId, Name = AuthOperationClaims.User};

            IEnumerable<OperationClaim> userFeatureOperationClaims = getFeatureOperationClaims(UserId);
            foreach (OperationClaim claim in userFeatureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Prompts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PromptsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PromptsOperationClaims.Read },
                new() { Id = ++lastId, Name = PromptsOperationClaims.Write },
                new() { Id = ++lastId, Name = PromptsOperationClaims.Create },
                new() { Id = ++lastId, Name = PromptsOperationClaims.Update },
                new() { Id = ++lastId, Name = PromptsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CustomizedImages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomizedImagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomizedImagesOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomizedImagesOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomizedImagesOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomizedImagesOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomizedImagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PromptCategories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PromptCategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PromptCategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = PromptCategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = PromptCategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = PromptCategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = PromptCategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Addresses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Gifts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GiftsOperationClaims.Admin },
                new() { Id = ++lastId, Name = GiftsOperationClaims.Read },
                new() { Id = ++lastId, Name = GiftsOperationClaims.Write },
                new() { Id = ++lastId, Name = GiftsOperationClaims.Create },
                new() { Id = ++lastId, Name = GiftsOperationClaims.Update },
                new() { Id = ++lastId, Name = GiftsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Layers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LayersOperationClaims.Admin },
                new() { Id = ++lastId, Name = LayersOperationClaims.Read },
                new() { Id = ++lastId, Name = LayersOperationClaims.Write },
                new() { Id = ++lastId, Name = LayersOperationClaims.Create },
                new() { Id = ++lastId, Name = LayersOperationClaims.Update },
                new() { Id = ++lastId, Name = LayersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Orders CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrdersOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Read },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Write },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Create },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Update },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region OrderItems CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrderItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrderItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = OrderItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = OrderItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = OrderItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = OrderItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        
        
        #region Placements CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PlacementsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PlacementsOperationClaims.Read },
                new() { Id = ++lastId, Name = PlacementsOperationClaims.Write },
                new() { Id = ++lastId, Name = PlacementsOperationClaims.Create },
                new() { Id = ++lastId, Name = PlacementsOperationClaims.Update },
                new() { Id = ++lastId, Name = PlacementsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Positions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PositionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PositionsOperationClaims.Read },
                new() { Id = ++lastId, Name = PositionsOperationClaims.Write },
                new() { Id = ++lastId, Name = PositionsOperationClaims.Create },
                new() { Id = ++lastId, Name = PositionsOperationClaims.Update },
                new() { Id = ++lastId, Name = PositionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region RetailCosts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RetailCostsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RetailCostsOperationClaims.Read },
                new() { Id = ++lastId, Name = RetailCostsOperationClaims.Write },
                new() { Id = ++lastId, Name = RetailCostsOperationClaims.Create },
                new() { Id = ++lastId, Name = RetailCostsOperationClaims.Update },
                new() { Id = ++lastId, Name = RetailCostsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
   
   
   #region Customizations CRUD
   featureOperationClaims.AddRange(
       [
           new() { Id = ++lastId, Name = CustomizationsOperationClaims.Admin },
           new() { Id = ++lastId, Name = CustomizationsOperationClaims.Read },
           new() { Id = ++lastId, Name = CustomizationsOperationClaims.Write },
           new() { Id = ++lastId, Name = CustomizationsOperationClaims.Create },
           new() { Id = ++lastId, Name = CustomizationsOperationClaims.Update },
           new() { Id = ++lastId, Name = CustomizationsOperationClaims.Delete },
       ]
   );
   #endregion
   
   
   #region PackingSlips CRUD
   featureOperationClaims.AddRange(
       [
           new() { Id = ++lastId, Name = PackingSlipsOperationClaims.Admin },
           new() { Id = ++lastId, Name = PackingSlipsOperationClaims.Read },
           new() { Id = ++lastId, Name = PackingSlipsOperationClaims.Write },
           new() { Id = ++lastId, Name = PackingSlipsOperationClaims.Create },
           new() { Id = ++lastId, Name = PackingSlipsOperationClaims.Update },
           new() { Id = ++lastId, Name = PackingSlipsOperationClaims.Delete },
       ]
   );
   #endregion
   
   
  
  
  #region Options CRUD
  featureOperationClaims.AddRange(
      [
          new() { Id = ++lastId, Name = OptionsOperationClaims.Admin },
          new() { Id = ++lastId, Name = OptionsOperationClaims.Read },
          new() { Id = ++lastId, Name = OptionsOperationClaims.Write },
          new() { Id = ++lastId, Name = OptionsOperationClaims.Create },
          new() { Id = ++lastId, Name = OptionsOperationClaims.Update },
          new() { Id = ++lastId, Name = OptionsOperationClaims.Delete },
      ]
  );
  #endregion
  
  
  
  
  #region TemplateProducts CRUD
  featureOperationClaims.AddRange(
      [
          new() { Id = ++lastId, Name = TemplateProductsOperationClaims.Admin },
          new() { Id = ++lastId, Name = TemplateProductsOperationClaims.Read },
          new() { Id = ++lastId, Name = TemplateProductsOperationClaims.Write },
          new() { Id = ++lastId, Name = TemplateProductsOperationClaims.Create },
          new() { Id = ++lastId, Name = TemplateProductsOperationClaims.Update },
          new() { Id = ++lastId, Name = TemplateProductsOperationClaims.Delete },
      ]
  );
  #endregion
  
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
