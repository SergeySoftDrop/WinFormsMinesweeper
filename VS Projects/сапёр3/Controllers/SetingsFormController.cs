using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using сапёр3.Setings;
using Сапёр3.Setings;

namespace сапёр3.Controllers
{
    static class SetingsFormController
    {
        private static Settings form;

        private static TrackBar MapXTrackBar;

        private static TrackBar MapYTrackBar;

        private static TrackBar BombsQuantityTrackBar;

        private static TrackBar CellSizeTrackBar;

        private static CheckBox EasyCheckBox;

        private static CheckBox MiddleCheckBox;

        private static CheckBox HardCheckBox;

        private static CheckBox UserCheckBox;

        public static bool Change;

        public static void Init(Settings setingsForm)
        {
            form = setingsForm;

            Change = false;

            MapXTrackBar = AppInterfaceController.GetMapXTrackBar();
            MapXTrackBar.Scroll += MapXTrackBarChange;
            MapYTrackBar = AppInterfaceController.GetMapYTrackBar();
            MapYTrackBar.Scroll += MapYTrackBarChange;
            BombsQuantityTrackBar = AppInterfaceController.GetBombsQuantityTrackBar();
            BombsQuantityTrackBar.Scroll += BombsQuantityTrackBarChange;
            CellSizeTrackBar = AppInterfaceController.GetCellSizeTrackBar();
            CellSizeTrackBar.Scroll += CellSizeTrackBarChange;

            EasyCheckBox = AppInterfaceController.GetEasyCheckBox();
            EasyCheckBox.MouseUp += EasyCheckBoxChange;
            MiddleCheckBox = AppInterfaceController.GetMiddleCheckBox();
            MiddleCheckBox.MouseUp += MiddleCheckBoxChange;
            HardCheckBox = AppInterfaceController.GetHardCheckBox();
            HardCheckBox.MouseUp += HardCheckBoxChange;
            UserCheckBox = AppInterfaceController.GetUserCheckBox();
            UserCheckBox.MouseUp += UserCheckBoxChange;
        }

        private static void EasyCheckBoxChange(Object sender, EventArgs e)
        {
            //DEBUG CODE 
            Console.WriteLine("ECBC: " + !EasyCheckBox.Checked + "\n");
            //
            SetingsPreset.Easy();
            SetChekBoxesFalse();
            EasyCheckBox.Checked = true;
            EasyCheckBox.CheckState = CheckState.Checked;
            SetSetingsValue();
            Change = true;
            
        }

        private static void MiddleCheckBoxChange(Object sender, EventArgs e)
        {
            //DEBUG CODE 
            Console.WriteLine("MCBC: " + !MiddleCheckBox.Checked + "\n");
            //
            SetingsPreset.Middle();
            SetChekBoxesFalse();
            MiddleCheckBox.Checked = true;
            MiddleCheckBox.CheckState = CheckState.Checked;
            SetSetingsValue();
            Change = true;
        }

        private static void HardCheckBoxChange(Object sender, EventArgs e)
        {

            //DEBUG CODE 
            Console.WriteLine("HCBC: " + !HardCheckBox.Checked + "\n");
            //
            SetingsPreset.Hard();
            SetChekBoxesFalse();
            HardCheckBox.Checked = true;
            HardCheckBox.CheckState = CheckState.Checked;
            SetSetingsValue();
            Change = true;
        }

        private static void UserCheckBoxChange(Object sender, EventArgs e)
        {            
            //DEBUG CODE 
            Console.WriteLine("UCBC: " + !UserCheckBox.Checked + "\n");
            //
            SetChekBoxesFalse();
            UserCheckBox.Checked = true;
            UserCheckBox.CheckState = CheckState.Checked;
        }

        private static void MapXTrackBarChange(Object sender, EventArgs e)
        {
            AppInterfaceController.SetValuMapXLabel(MapXTrackBar.Value);

            GameSetings.MapSize[0] = MapXTrackBar.Value;

            CheckBombsQuantytiValue();

            BombsQuantityTrackBar.Maximum = Math.Abs((GameSetings.MapSize[0] * GameSetings.MapSize[1]) / 4);

            SetChangeTrue();

            if (!ChekUserCheckBox())
            {
                SetChekBoxesFalse();
                UserCheckBox.Checked = true;
            }
        }

        private static void MapYTrackBarChange(Object sender, EventArgs e)
        {
            AppInterfaceController.SetValuMapYLabele(MapYTrackBar.Value);

            GameSetings.MapSize[1] = MapYTrackBar.Value;

            CheckBombsQuantytiValue();

            BombsQuantityTrackBar.Maximum = Math.Abs((GameSetings.MapSize[0] * GameSetings.MapSize[1]) / 4);

            SetChangeTrue();

            if (!ChekUserCheckBox())
            {
                SetChekBoxesFalse();
                UserCheckBox.Checked = true;
                UserCheckBox.CheckState = CheckState.Checked;
            }
        }

        private static void BombsQuantityTrackBarChange(Object sender, EventArgs e)
        {
            AppInterfaceController.SetValueBombsQuantityLabel(BombsQuantityTrackBar.Value);

            GameSetings.BombsQuantity = BombsQuantityTrackBar.Value;

            SetChangeTrue();

            if (!ChekUserCheckBox())
            {
                SetChekBoxesFalse();
                UserCheckBox.Checked = true;
            }
        }

        private static void CellSizeTrackBarChange(Object sender, EventArgs e)
        {
            AppInterfaceController.SetValueCellSizeLabel(CellSizeTrackBar.Value);

            GameSetings.CellSize = CellSizeTrackBar.Value;

            //DEBUG CODE
            Console.WriteLine("CSTB set size value: " + CellSizeTrackBar.Value + "\n");
            //

            SetChangeTrue();
        }

        private static bool ChekUserCheckBox()
        {
            return UserCheckBox.Checked ? true : false;
        }

        private static void SetChangeTrue()
        {
            if (!Change)
            {
                Change = true;
            }
        }

        private static void SetChekBoxesFalse()
        {
            EasyCheckBox.Checked = false;
            EasyCheckBox.CheckState = CheckState.Unchecked;
            MiddleCheckBox.Checked = false;
            MiddleCheckBox.CheckState = CheckState.Unchecked;
            HardCheckBox.Checked = false;
            HardCheckBox.CheckState = CheckState.Unchecked;
            UserCheckBox.Checked = false;
            UserCheckBox.CheckState = CheckState.Unchecked;
        }

        private static void CheckBombsQuantytiValue()
        {
            if (BombsQuantityTrackBar.Value > Math.Abs((GameSetings.MapSize[0] * GameSetings.MapSize[1]) / 4))
            {
                BombsQuantityTrackBar.Value = Math.Abs((GameSetings.MapSize[0] * GameSetings.MapSize[1]) / 4);
                AppInterfaceController.SetValueBombsQuantityLabel(BombsQuantityTrackBar.Value);
            }
        }

        private static void SetSetingsValue()
        {
            //DEBUG CODE
            Console.WriteLine("SSV value: ");
            Console.WriteLine("MapSizeX: " + GameSetings.MapSize[0]);
            Console.WriteLine("MapSizeY: " + GameSetings.MapSize[1]);
            Console.WriteLine("BombsQuantity: " + GameSetings.BombsQuantity + "\n");
            //

            AppInterfaceController.SetValuMapXLabel(GameSetings.MapSize[0]);
            MapXTrackBar.Value = GameSetings.MapSize[0];

            AppInterfaceController.SetValuMapYLabele(GameSetings.MapSize[1]);
            MapYTrackBar.Value = GameSetings.MapSize[1];

            AppInterfaceController.SetValueBombsQuantityLabel(GameSetings.BombsQuantity);
            BombsQuantityTrackBar.Maximum = Math.Abs((GameSetings.MapSize[0] * GameSetings.MapSize[1]) / 4);
            BombsQuantityTrackBar.Value = GameSetings.BombsQuantity;
        }
    }
}
