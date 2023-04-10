using System;
using GoTTest.Model.Data;
using GoTTest.Model.Definitions;
using GoTTest.Model.Definitions.Shop;
using GoTTest.Services;
using UnityEngine;

namespace GoTTest.Model
{
    public class ShopModel
    {
        private readonly PlayerData _data;
        
        public event Action<string> OnBuyLot;

        public ShopModel(PlayerData data)
        {
            _data = data;
        }
        
        public void BuyLot(string id)
        {
            var lotDef = DefsFacade.I.ShopRepository.Get(id);

            //Тут должна быть логика на проверку ресурсов для покупки лота
            //но в данном задании нет нужды полностью реализовывать магазин
            //так что это просто для примера как оно должно работать
            var isEnoughResources = true;
            
            if (!isEnoughResources) return;

            if (lotDef is MultiplyLot lot)
            {
                var nextLevel = GameSession.Instance.Data.PurchasesData.GetPurchaseState(id) + 1;
                if (lot.Levels.Length <= nextLevel)
                {
                    Debug.LogError(Idents.Errors.AlreadyBoughtItems + id);
                    return;
                }
            }
            
            _data.PurchasesData.MakePurchase(id);

            OnBuyLot?.Invoke(id);
        }
    }
}