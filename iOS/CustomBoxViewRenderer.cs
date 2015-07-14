using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;
using CoreGraphics;

// CustomBoxViewのレンダラーをCustomBoxRendererに変更する宣言
[assembly:ExportRenderer(typeof(CustomBox.CustomBoxView), typeof(CustomBox.iOS.CustomBoxViewRenderer))]
namespace CustomBox.iOS
{
	/// <summary>
	/// BoxViewに対応した、BoxViewRendererを継承したクラスをカスタムレンダラークラスとして作成
	/// </summary>
	public class CustomBoxViewRenderer : Xamarin.Forms.Platform.iOS.BoxRenderer
	{
		Color customColor;

		Color backColor;
		
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);

			if (Element != null)
			{
				customColor = Element.Color;
				backColor = Element.BackgroundColor;
			}
		}

		public override void Draw(CoreGraphics.CGRect rect)
		{
			//base.Draw(rect);

			// Elementをキャストしてformsで定義したCustomBoxViewを取得
			var formsBox = (CustomBoxView)Element;

			// iOSの描画はContextを使用
			using (var context = UIGraphics.GetCurrentContext())
			{
				// 吹き出しの設定
				// 色の設定
				context.SetFillColor(formsBox.FillColor.ToCGColor());

				// スタート位置の設定
				context.MoveTo(0, 0);

				// 結ぶ位置の設定
				context.AddLineToPoint(100, 10);
				context.AddLineToPoint(100, 100);

				// 設定した点を繋げる
				context.ClosePath();

				// 描画
				context.DrawPath(CGPathDrawingMode.Fill);

				// 角の丸い四角の設定
				// 角丸の設定
				// widthとheightを比較して小さい方を基準にする
				var minSize = (float)Math.Min(rect.Width, rect.Height);

				var radius = formsBox.Radius;
				// 指定するのは半径なので、minSize / 2以下でなければならない
				if (formsBox.Radius > minSize / 2)
					radius = minSize / 2;

				// パスの取得
				var path = CGPath.FromRoundedRect(rect, radius, radius);

				// コンテキストにパスを追加
				context.AddPath(path);

				// コンテキストを描画
				context.DrawPath(CGPathDrawingMode.Fill);
			}
		}
	}
}


