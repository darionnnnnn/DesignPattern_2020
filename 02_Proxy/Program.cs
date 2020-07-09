using System;

namespace _02_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IBuyHouse littleEngineer = new Buyer();
            IBuyHouse estateAgent = new EstateAgent(littleEngineer);

            estateAgent.SearchGoodHouse();
            estateAgent.ViewTheHouse();
            estateAgent.Bargain();
            estateAgent.finish();

            Console.ReadLine();
        }

        /// <summary>
        /// 買房介面
        /// </summary>
        public interface IBuyHouse
        {
            // 找好房子
            public void SearchGoodHouse();
            // 預約看屋
            public void ViewTheHouse();
            // 討價還價
            public void Bargain();
            // 成交後，簡化從付訂金到交屋的過程。
            public void finish();
        }

        /// <summary>
        /// 買方實作
        /// </summary>
        public class Buyer : IBuyHouse
        {
            public void SearchGoodHouse()
            {
                // 請房仲幫忙找房子
                Console.WriteLine("買方：我想找蛋黃區的小坪數老公寓！");
            }

            public void ViewTheHouse()
            {
                // 預約房仲看找到的房子
                Console.WriteLine("買方：Hi, 我想要看 OOO 物件！");
            }

            public void Bargain()
            {
                // 看了很喜歡，決定下斡，跟屋主議價一翻
                Console.WriteLine("買方：拜託便宜點吧！");
            }

            public void finish()
            {
                // 沒想到屋主同意買到了
                Console.WriteLine("買方：簽約、交屋、還貸款！");
            }
        }

        /// <summary>
        /// 房仲
        /// </summary>
        public class EstateAgent : IBuyHouse
        {
            private IBuyHouse _BuyHouse;

            public EstateAgent(IBuyHouse buyHouse)
            {
                _BuyHouse = buyHouse;
            }

            public void SearchGoodHouse()
            {
                _BuyHouse.SearchGoodHouse();
                Console.WriteLine("房仲：找房～找房～");
            }

            public void ViewTheHouse()
            {
                _BuyHouse.ViewTheHouse();
                Console.WriteLine("房仲：帶看～帶看～");
            }

            public void Bargain()
            {
                _BuyHouse.Bargain();
                Console.WriteLine("房仲：帶著買方預算找屋主喬價錢～");
            }

            public void finish()
            {
                _BuyHouse.finish();
                Console.WriteLine("房仲：皆大歡喜～");
            }
        }
    }
}