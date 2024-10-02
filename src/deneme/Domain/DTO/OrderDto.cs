using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class OrderDto : IDto
{
    public string external_id { get; set; } // Mevcut Order ID
    public string shipping { get; set; } = "STANDARD"; // Varsayılan değer
    public AddressDto recipient { get; set; } // Alıcı bilgileri
    public List<OrderItemDto>? order_items { get; set; } // Sipariş kalemleri
    public RetailCostDto? retail_cost { get; set; } // Perakende maliyeti

    public static OrderDto ConvertToDto(Order order, Address address, List<OrderItem>? orderItems, RetailCost? retailCost)
    {
        return new OrderDto
        {
            external_id = "@" + order.Id.ToString(), // Entity ID'si API'nin external_id alanına
            shipping = order.Shipping ?? "STANDARD", // Varsayılan değer olarak "STANDARD"
            recipient = new AddressDto
            {
                name = address.Name,
                company = address.Company,
                address1 = address.Address1,
                address2 = address.Address2,
                city = address.City,
                state_code = address.StateCode,
                state_name = address.StateName,
                country_code = address.CountryCode,
                country_name = address.CountryName,
                zip = address.Zip,
                phone = address.Phone,
                email = address.Email,
                tax_number = address.TaxNumber
            },
            order_items = orderItems?.Select(item => new OrderItemDto
            {
                source = item.Source ?? "catalog",
                catalog_variant_id = item.CatalogVariantId,
                //external_id = item.ExternalId,
                quantity = item.Quantity,
                retail_price = item.RetailPrice,
                name = item.Name,
                placements = item.Placements.Select(placement => new PlacementDto
                {
                    placement = placement.PlacementName,
                    technique = placement.Technique,
                    layers = placement.Layers.Select(layer => new LayerDto
                    {
                        type = layer.Type,
                        url = layer.Url,
                        // layer_options = layer.LayerOptions?.Select(option => new LayerOptionDto
                        // {
                        //     // Layer options here
                        // }).ToList(),
                        position = new LayerPositionDto
                        {
                            width = layer.Position.Width,
                            height = layer.Position.Height,
                            top = layer.Position.Top,
                            left = layer.Position.Left
                        }
                    }).ToList(),
                    // placement_options = placement.PlacementOptions?.Select(option => new PlacementOptionDto
                    // {
                    //     // Placement options here
                    // }).ToList()
                }).ToList()
            }).ToList(),
            retail_cost = retailCost != null ? new RetailCostDto
            {
                currency = retailCost.Currency,
                discount = retailCost.Discount,
                shipping = retailCost.Shipping,
                tax = retailCost.Tax
            } : null
        };
    }


}


