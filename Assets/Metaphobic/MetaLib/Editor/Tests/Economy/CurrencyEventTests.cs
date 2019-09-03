using DwarvenSoftware.Framework.Economy;
using DwarvenSoftware.Framework.Economy.Events;
using DwarvenSoftware.Framework.Events;
using DwarvenSoftware.Framework.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace DwarvenSoftware.Framework.Editor.Tests.Economy
{
    public class CurrencyEventTests
    {
        [Test]
        public void CurrencyEvent_CurrencyAdded()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            
            DSEvents.Add(new DSEvents.EventDelegate<CurrencyAddedEvent>(e => Debug.Log(e.Currency.Name)));
            
            currency.Add(5);
            
            LogAssert.Expect(LogType.Log, name);
        }
        
        [Test]
        public void CurrencyEvent_CurrencySpent()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            
            DSEvents.Add(new DSEvents.EventDelegate<CurrencySpentEvent>((e => {Debug.Log(e.Amount);})));
            
            currency.Add(5);
            currency.TrySpend(2);
            
            LogAssert.Expect(LogType.Log, "2");
        }
        
        [Test]
        public void CurrencyEvent_CurrencyInsufficient()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            
            DSEvents.Add(new DSEvents.EventDelegate<CurrencyInsufficientEvent>((e => {Debug.Log(e.AmountAttempted);})));
            
            currency.Add(5);
            currency.TrySpend(7);
            
            LogAssert.Expect(LogType.Log, "7");
        }
        
        [Test]
        public void CurrencyEvent_UpgradableCurrencyUpgraded()
        {
            var name = DSUtils.GetRandomString();
            var capacity = new CappedCurrencyCapacity(5, 10);
            IUpgradableCurrency currency = new DSCappedCurrency(name, capacity);
            
            DSEvents.Add(new DSEvents.EventDelegate<UpgradableCurrencyUpgradeSuccessEvent>((e => {Debug.Log(e.Currency.Name);})));

            currency.TryUpgradeCapacity();
            
            LogAssert.Expect(LogType.Log, name);
        }
        
        [Test]
        public void CurrencyEvent_UpgradableCurrencyUpgradeFailed()
        {
            var name = DSUtils.GetRandomString();
            var capacity = new CappedCurrencyCapacity(5, 10);
            IUpgradableCurrency currency = new DSCappedCurrency(name, capacity);
            
            DSEvents.Add(new DSEvents.EventDelegate<UpgradableCurrencyUpgradeFailedEvent>((e => {Debug.Log("Upgrade Failed");})));

            currency.TryUpgradeCapacity();
            currency.TryUpgradeCapacity();
            
            LogAssert.Expect(LogType.Log, "Upgrade Failed");
        }
    }
}