
using LibSDK.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
   partial class BoardSwitchCs
    {
        public BoardSwitchCs() { }

        //卡的扩展
        private CardInterface CardLib(CardType _cardType)
        {
            CardInterface @interface = null;

            switch (_cardType)
            {
                case CardType.GTS:
                    @interface = new GTS();
                    break;
                case CardType.LTDMC:
                    @interface = new DMC();
                    break;
                case CardType.GCS:
                    @interface = new GCS();
                    break;
            }
            return @interface;
        }
        
        public CardInterface API { get => CardLib(MotionControl.EnumControl.CardType); }

        private IOInterface IoCardLib(IOType iOType)
        {
            IOInterface @IOInterface = null;
            switch (iOType)
            {
                case IOType.DMC640:
                    @IOInterface = new Dmc6040();
                    break;
            }
            return @IOInterface;
        }
        public IOInterface IoAPI { get => IoCardLib(MotionControl.EnumControl.IOType); }
    }
}
