using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ToDoList
{
    public partial class ShopForm : MaterialForm
    {
        private ToDoList mainForm;

        // 구매여부와 포인트는 예시로 static
        private static int userPoints = 100;  // 시작 포인트

        private static Dictionary<string, bool> boughtThemes = new Dictionary<string, bool>
    {
        { "Blue", true }, // 기본 제공
        { "Red", false },
        { "Green", false }

    };

        public ShopForm(ToDoList main)
        {

            InitializeComponent();// label 색상 변경
            labelPoints.ForeColor = Color.Blue;      // 원하는 색
            labelPoints.BackColor = Color.Transparent; // 배경은 보통 투명

            // 폰트 변경
            labelPoints.Font = new Font("맑은 고딕", 14, FontStyle.Bold);
            mainForm = main;

            // 테마 리스트 표시
            // (Button 3개 + Label 3개 등으로 간단하게 구현)
            UpdateShopUI();

            btnApplyRed.Visible = false;
            btnApplyGreen.Visible = false;
        }
        private void UpdateShopUI()
        {
            // 예시: 각 테마에 대해
            // 1. 구매 안했으면 "구매" 버튼 활성, 가격 표시
            // 2. 구매했으면 "적용" 버튼 활성
            btnApplyBlue.Enabled = true;

            labelPoints.Text = $"보유 포인트: {userPoints}";
            btnBuyRed.Enabled = !boughtThemes["Red"] && userPoints >= 50;
            btnApplyRed.Enabled = boughtThemes["Red"];

            btnBuyGreen.Enabled = !boughtThemes["Green"] && userPoints >= 50;
            btnApplyGreen.Enabled = boughtThemes["Green"];
        }

        private void btnBuyGreen_Click(object sender, EventArgs e)
        {
            if (userPoints >= 50)
            {
                btnBuyGreen.Visible = false;
                btnApplyGreen.Visible = true;
                boughtThemes["Green"] = true;
                userPoints -= 50;
                UpdateShopUI();
            }
        }


        private void btnApplyGreen_Click(object sender, EventArgs e)
        {
            mainForm.ApplyTheme("Green");
        }
        private void btnBuyRed_Click(object sender, EventArgs e)
        {
            if (userPoints >= 50)
            {
                btnBuyRed.Visible = false;
                btnApplyRed.Visible = true;
                boughtThemes["Red"] = true;
                userPoints -= 50;
                UpdateShopUI();
            }
        }

        private void btnApplyRed_Click(object sender, EventArgs e)
        {
            mainForm.ApplyTheme("Red");
        }
        private void btnApplyBlue_Click(object sender, EventArgs e)
        {
            mainForm.ApplyTheme("Blue");
        }
    }
}
