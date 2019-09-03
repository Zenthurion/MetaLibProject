using MetaLib.Economy;
using MetaLib.Economy.Events;
using MetaLib.Events;
using MetaLib.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MetaLib.Editor.Tests.Economy
{
    public class CurrencyEventTests
    {
        [Test]
        public void CurrencyEvent_CurrencyAdded()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            
            MEvents.Add(new MEvents.EventDelegate<CurrencyAddedEvent>(e => Debug.Log(e.Currency.Name)));
            
            currency.Add(5);
            
            LogAssert.Expect(LogType.Log, name);
        }
        
        [Test]
        public void CurrencyEvent_CurrencySpent()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            
            MEvents.Add(new MEvents.EventDelegate<CurrencySpentEvent>((e => {Debug.Log(e.Amount);})));
            
            currency.Add(5);
            currency.TrySpend(2);
            
            LogAssert.Expect(LogType.Log, "2");
        }
        
        [Test]
        public void CurrencyEvent_CurrencyInsufficient()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            
            MEvents.Add(new MEvents.EventDelegate<CurrencyInsufficientEvent>((e => {Debug.Log(e.AmountAttempted);})));
            
            currency.Add(5);
            currency.TrySpend(7);
            
            LogAssert.Expect(LogType.Log, "7");
        }
        
        [Test]
        public void CurrencyEvent_UpgradableCurrencyUpgraded()
        {
            var name = MUtils.GetRandomString();
            var capacity = new CappedCurrencyCapacity(5, 10);
            IUpgradableCurrency currency = new MCappedCurrency(name, capacity);
            
            MEvents.Add(new MEvents.EventDelegate<UpgradableCurrencyUpgradeSuccessEvent>((e => {Debug.Log(e.Currency.Name);})));

            currency.TryUpgradeCapacity();
            
            LogAssert.Expect(LogType.Log, name);
        }
        
        [Test]
        public void CurrencyEvent_UpgradableCurrencyUpgradeFailed()
        {
            var name = MUtils.GetRandomString();
            var capacity = new CappedCurrencyCapacity(5, 10);
            IUpgradableCurrency currency = new MCappedCurrency(name, capacity);
            
            MEvents.Add(new MEvents.EventDelegate<UpgradableCurrencyUpgradeFailedEvent>((e => {Debug.Log("Upgrade Failed");})));

            currency.TryUpgradeCapacity();
            currency.TryUpgradeCapacity();
            
            LogAssert.Expect(LogType.Log, "Upgrade Failed");
        }
    }
}