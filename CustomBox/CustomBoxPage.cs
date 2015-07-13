using System;

using Xamarin.Forms;

namespace CustomBox
{
	public class CustomBoxPage : ContentPage
	{
		public CustomBoxPage()
		{
			// CustomBoxViewの生成
			var customBox = new CustomBoxView()
			{
				Color = Color.Purple,
			};

			// レイアウトを生成
			var stackLayout = new StackLayout
			{
				// レイアウトにCustomBoxViewを追加
				Children =
				{
					customBox,
				}
			};

			// ページのコンテントにレイアウトを設定
			Content = stackLayout;
		}
	}
}


