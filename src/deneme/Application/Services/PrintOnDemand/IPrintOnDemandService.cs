using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PrintOnDemand;
public interface IPrintOnDemandService
{
    void CreateOrder(Order order);
    Order GetByIdOrder(Guid OrderId);

    List<Order> GetOrderList();
    void DeleteOrder(Guid Order);




    void CreateAddress(Address address);

    Address GetAddress(Guid AddressId);

    List<Address> GetAddresses();
    void DeleteAddress(Guid AddressId);


    void CreateCustomization(Customization customization);
    Customization GetCustomizationById(Guid customizationId);
    List<Customization> GetCustomizationList();
    void DeleteCustomization(Guid customizationId);


    void CreateGift(Gift gift);
    Gift GetGiftById(Guid giftId);
    List<Gift> GetGiftList();
    void DeleteGift(Guid giftId);


    void CreateLayer(Layer layer);
    Layer GetLayerById(Guid layerId);
    List<Layer> GetLayerList();
    void DeleteLayer(Guid layerId);


    void CreateOrderItem(OrderItem orderItem);
    OrderItem GetOrderItemById(Guid orderItemId);
    List<OrderItem> GetOrderItemList();
    void DeleteOrderItem(Guid orderItemId);


    void CreatePackingSlip(PackingSlip packingSlip);
    PackingSlip GetPackingSlipById(Guid packingSlipId);
    List<PackingSlip> GetPackingSlipList();
    void DeletePackingSlip(Guid packingSlipId);


    void CreatePlacement(Placement placement);
    Placement GetPlacementById(Guid placementId);
    List<Placement> GetPlacementList();
    void DeletePlacement(Guid placementId);


    void CreatePosition(Position position);
    Position GetPositionById(Guid positionId);
    List<Position> GetPositionList();
    void DeletePosition(Guid positionId);


    void CreateRetailCost(RetailCost retailCost);
    RetailCost GetRetailCostById(Guid retailCostId);
    List<RetailCost> GetRetailCostList();
    void DeleteRetailCost(Guid retailCostId);


}
