using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Colors.Constants;
using Application.Features.ProductImages.Constants;
using Application.Features.PrintAreas.Constants;
using Application.Features.PrintAreaNames.Constants;
using Application.Features.CustomizedImages.Constants;
using Application.Features.CustomizedProducts.Constants;
using Application.Features.Addresses.Constants;
using Application.Features.OrderDetails.Constants;
using Application.Features.Orders.Constants;
using Application.Features.OrderTransports.Constants;
using Application.Features.Prompts.Constants;
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

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
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

        

        #region Categories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Colors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ColorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Read },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Write },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Create },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Update },
                new() { Id = ++lastId, Name = ColorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        
        
        #region ProductImages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Read },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Write },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Create },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Update },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ProductImages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Read },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Write },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Create },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Update },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PrintAreas CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PrintAreasOperationClaims.Admin },
                new() { Id = ++lastId, Name = PrintAreasOperationClaims.Read },
                new() { Id = ++lastId, Name = PrintAreasOperationClaims.Write },
                new() { Id = ++lastId, Name = PrintAreasOperationClaims.Create },
                new() { Id = ++lastId, Name = PrintAreasOperationClaims.Update },
                new() { Id = ++lastId, Name = PrintAreasOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PrintAreaNames CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PrintAreaNamesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PrintAreaNamesOperationClaims.Read },
                new() { Id = ++lastId, Name = PrintAreaNamesOperationClaims.Write },
                new() { Id = ++lastId, Name = PrintAreaNamesOperationClaims.Create },
                new() { Id = ++lastId, Name = PrintAreaNamesOperationClaims.Update },
                new() { Id = ++lastId, Name = PrintAreaNamesOperationClaims.Delete },
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
        
        
        #region CustomizedProducts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CustomizedProductsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CustomizedProductsOperationClaims.Read },
                new() { Id = ++lastId, Name = CustomizedProductsOperationClaims.Write },
                new() { Id = ++lastId, Name = CustomizedProductsOperationClaims.Create },
                new() { Id = ++lastId, Name = CustomizedProductsOperationClaims.Update },
                new() { Id = ++lastId, Name = CustomizedProductsOperationClaims.Delete },
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
        
        
        
        #region OrderDetails CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Read },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Write },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Create },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Update },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Delete },
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
        
        
        
        #region OrderTransports CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrderTransportsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrderTransportsOperationClaims.Read },
                new() { Id = ++lastId, Name = OrderTransportsOperationClaims.Write },
                new() { Id = ++lastId, Name = OrderTransportsOperationClaims.Create },
                new() { Id = ++lastId, Name = OrderTransportsOperationClaims.Update },
                new() { Id = ++lastId, Name = OrderTransportsOperationClaims.Delete },
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
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
