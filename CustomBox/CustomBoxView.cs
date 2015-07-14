using System;

using Xamarin.Forms;

namespace CustomBox
{
	public class CustomBoxView : BoxView
	{
		// 角丸のサイズ
		public float Radius;

		// 塗りつぶし色
		public Color FillColor;

		public CustomBoxView(Color fillColor, float radius)
		{
			// iOSでこの色が必ず描画されてしまうので、透明に設定しておく必要がある
			Color = Color.Transparent;

			// 塗りつぶす色の設定
			FillColor = fillColor;

			// 角丸サイズの設定
			Radius = radius;

			// レイアウトの初期化
			VerticalOptions = LayoutOptions.Center;
		}
	}
}


