using Economy;
using Economy.Events;
using Events;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utils;

namespace Editor.Tests.Economy
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
        public void CurrencyEvent_RestrictedCurrencyUpgraded()
        {
            var name = DSUtils.GetRandomString();
            var capacity = new CappedCurrencyCapacity(5, 10);
            ICappedCurrency currency = new DSCappedCurrency(name, capacity);
            
            DSEvents.Add(new DSEvents.EventDelegate<CappedCurrencyUpgradeSuccessEvent>((e => {Debug.Log(e.Currency.Name);})));

            currency.TryUpgradeCapacity();
            
            LogAssert.Expect(LogType.Log, name);
        }
        
        [Test]
        public void CurrencyEvent_RestrictedCurrencyUpgradeFailed()
        {
            var name = DSUtils.GetRandomString();
            var capacity = new CappedCurrencyCapacity(5, 10);
            ICappedCurrency currency = new DSCappedCurrency(name, capacity);
            
            DSEvents.Add(new DSEvents.EventDelegate<CappedCurrencyUpgradeFailedEvent>((e => {Debug.Log("Upgrade Failed");})));

            currency.TryUpgradeCapacity();
            currency.TryUpgradeCapacity();
            
            LogAssert.Expect(LogType.Log, "Upgrade Failed");
        }
    }
}