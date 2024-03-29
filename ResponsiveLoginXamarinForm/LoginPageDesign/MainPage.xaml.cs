﻿
using ResponsiveRegistrationForm;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace LoginPageDesign
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        OrientationValue deviceOrientation;
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OrientationChanged(OrientationValue newOrientation)
        {
            base.OrientationChanged(newOrientation);
            deviceOrientation = newOrientation;
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {

            if (Device.Idiom == TargetIdiom.Tablet)
                TabletView(args, deviceOrientation);
            else
                MobileView(args, deviceOrientation);

        }

        private void PaintLandScapeBackground(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * 0.57f, 0);

                path.CubicTo(info.Width * 0.54f, info.Height * 0.14f,
                             info.Width * 0.46f, info.Height * 0.24f,
                             info.Width * 0.46f, info.Height * 0.45f);
                path.CubicTo(info.Width * 0.46f, info.Height * 0.68f,
                             info.Width * 0.57f, info.Height * 0.83f,
                             info.Width * 0.6f, info.Height);
                path.LineTo(0, info.Height);
                path.Close();


                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = SKColor.Parse("#9b1d75");

                    paint.Shader = SKShader.CreateLinearGradient(
                                            new SKPoint(info.Width * 0.6f, info.Height),
                                            new SKPoint(0, 0),
                                            new SKColor[] { Color.FromHex("#511694").ToSKColor(), Color.FromHex("#9b1d75").ToSKColor() },
                                            new float[] { 0.18f, 1 },
                                            SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }
            }
        }

        private void PaintPortraitBackground(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(0, info.Height * 0.37f);

                path.CubicTo(info.Width * 0.14f, info.Height * 0.34f,
                             info.Width * 0.24f, info.Height * 0.26f,
                             info.Width * 0.45f, info.Height * 0.26f);
                path.CubicTo(info.Width * 0.68f, info.Height * 0.26f,
                             info.Width * 0.83f, info.Height * 0.37f,
                             info.Width, info.Height * 0.4f);
                path.LineTo(info.Width, 0);
                path.Close();


                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = SKColor.Parse("#9b1d75");

                    paint.Shader = SKShader.CreateLinearGradient(
                                            new SKPoint(0, info.Height * 0.54f),
                                            new SKPoint(info.Width, 0),
                                            new SKColor[] { Color.FromHex("#511694").ToSKColor(), Color.FromHex("#9b1d75").ToSKColor() },
                                            new float[] { 0.18f, 1 },
                                            SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }
            }
        }

        private void TabletView(SKPaintSurfaceEventArgs args, OrientationValue deviceOrientation)
        {
            Username.Margin = new Thickness(0, 25, 0, 0);
            Password.Margin = new Thickness(0, 20, 0, 0);
            LoginButton.Margin = new Thickness(0, 25, 0, 0);
            FormTitle.FontSize = 30;
            LoginFormFrame.HasShadow = false;
            LogoSectionInner.VerticalOptions = LayoutOptions.EndAndExpand;

            if (deviceOrientation == OrientationValue.Landscape)
            {
                PaintLandScapeBackground(args);
                LandScapeViewCommon();

                FlexLayout.SetBasis(CompanyInfo, new FlexBasis(0.55f, true));
                FlexLayout.SetBasis(LoginForm, new FlexBasis(0.45f, true));
                FlexLayout.SetBasis(LogoSection, new FlexBasis(0.35f, true));

                LoginFormFrame.Margin = new Thickness(60, 0);
                LoginFormFrame.Padding = new Thickness(0);

                AppInfo.IsVisible = true;
                AppInfoImage.IsVisible = true;

                Logo.HorizontalOptions = LayoutOptions.Start;

                FormTitle.HorizontalTextAlignment = TextAlignment.Start;

                LogoSection.Padding = new Thickness(60, 20, 120, 20);
            }
            else
            {
                PaintPortraitBackground(args);
                PortraitViewCommon();

                LoginFormFrame.Padding = new Thickness(30, 40);
                LoginFormFrame.Margin = new Thickness(80);
                
                Logo.HorizontalOptions = LayoutOptions.CenterAndExpand;
                Logo.WidthRequest = 300;
            }
        }

        private void MobileView(SKPaintSurfaceEventArgs args, OrientationValue deviceOrientation )
        {
            Username.Margin = new Thickness(0, 15, 0, 0);
            Password.Margin = new Thickness(0, 15, 0, 0);
            LoginButton.Margin = new Thickness(0, 15, 0, 0);

            FormTitle.FontSize = 25;

            if (deviceOrientation == OrientationValue.Landscape)
            {
                PaintLandScapeBackground(args);
                LandScapeViewCommon();

                FlexLayout.SetBasis(CompanyInfo, new FlexBasis(0.35f, true));
                FlexLayout.SetBasis(LoginForm, new FlexBasis(0.65f, true));
                FlexLayout.SetBasis(LogoSection, new FlexBasis(1, true));

                LoginFormFrame.HasShadow = true;
                LoginFormFrame.Margin = new Thickness(0, 30, 70, 30);
                LoginFormFrame.Padding = new Thickness(20);
                LoginFormFrame.BackgroundColor = Color.White;

                AppInfo.IsVisible = true;
                AppInfoImage.IsVisible = false;

                LogoSection.Padding = new Thickness(21, 0);

                LogoSectionInner.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
            else
            {
                PaintPortraitBackground(args);
                PortraitViewCommon();

                LoginFormFrame.Padding = new Thickness(20, 40);
                LoginFormFrame.Margin = new Thickness(30, 0);
                LoginFormFrame.HasShadow = false;

                Logo.WidthRequest = 200;

                LogoSectionInner.VerticalOptions = LayoutOptions.EndAndExpand;
            }
        }

        private void PortraitViewCommon()
        {
            PageLayout.Direction = FlexDirection.Column;
            AppInfo.IsVisible = false;
            AppInfoImage.IsVisible = false;

            LoginFormFrame.BackgroundColor = Color.Transparent;

            Logo.VerticalOptions = LayoutOptions.EndAndExpand;

            LogoSection.Padding = new Thickness(0);

            FormTitle.HorizontalTextAlignment = TextAlignment.Center;

            FlexLayout.SetBasis(CompanyInfo, new FlexBasis(0.2f, true));
            FlexLayout.SetBasis(LoginForm, new FlexBasis(0.8f, true));
            FlexLayout.SetBasis(LogoSection, new FlexBasis(1, true));
        }

        private void LandScapeViewCommon()
        {
            PageLayout.Direction = FlexDirection.Row;
            Logo.WidthRequest = 200;
        }

        private void SKCanvasView_PaintSurface_1(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKRect rect = new SKRect(0, 0, info.Width, info.Height);

                paint.Shader = SKShader.CreateLinearGradient(
                                        new SKPoint(0, info.Height / 2),
                                        new SKPoint(info.Width, info.Height / 2),
                                         new SKColor[] { Color.FromHex("#9b1d75").ToSKColor(), Color.FromHex("#511694").ToSKColor()},
                                        new float[] { 0.15f, 1 },
                                        SKShaderTileMode.Clamp);

                canvas.DrawRect(rect, paint);
            }

        }

        private void SKCanvasView_PaintSurface_2(object sender, SKPaintSurfaceEventArgs args)
        {

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float[] borderDot = new float[]{ 5, 5 };

            SKPaint paint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 1,
                PathEffect = SKPathEffect.CreateDash(borderDot, 10)  
            };

            Assembly assembly = GetType().GetTypeInfo().Assembly;

            if ((SKCanvasView)sender == Center)
            {
                string resourceID = "LoginPageDesign.images.mainImage.png";
                using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                {
                    var resourceBitmap = SKBitmap.Decode(stream);
                    if (resourceBitmap != null)
                    {
                        canvas.DrawCircle(0.42f * info.Width, 0.5f * info.Height, 110, paint);
                        canvas.DrawBitmap(resourceBitmap, ((0.42f * info.Width) - 110), (0.5f * info.Height) - 110);
                    }
                }
            }

            if ((SKCanvasView)sender == Right)
            {
                string resourceID = "LoginPageDesign.images.grocery.png";
                using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                {
                    var resourceBitmap = SKBitmap.Decode(stream);
                    if (resourceBitmap != null)
                    {
                        canvas.DrawCircle((0.42f * info.Width) + 110, 0.5f * info.Height, 20, paint);
                        canvas.DrawBitmap(resourceBitmap, ((0.42f * info.Width) + 110) - 10, (0.5f * info.Height) - 10);
                    }
                }
            }

            if ((SKCanvasView)sender == Left)
            {
                string resourceID = "LoginPageDesign.images.location.png";
                using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                {
                    var resourceBitmap = SKBitmap.Decode(stream);
                    if (resourceBitmap != null)
                    {
                        canvas.DrawCircle((0.42f * info.Width) - 110, 0.5f * info.Height, 20, paint);
                        canvas.DrawBitmap(resourceBitmap, ((0.42f * info.Width) - 110) - 10, (0.5f * info.Height) - 10);
                    }
                }
            }
            if ((SKCanvasView)sender == Top)
            {
                string resourceID = "LoginPageDesign.images.phone.png";
                using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                {
                    var resourceBitmap = SKBitmap.Decode(stream);
                    if (resourceBitmap != null)
                    {
                        canvas.DrawCircle(0.42f * info.Width, (0.5f * info.Height) - 110, 20, paint);
                        canvas.DrawBitmap(resourceBitmap, (0.42f * info.Width) - 10, ((0.5f * info.Height) - 110) - 10);
                    }
                }
            }

            if ((SKCanvasView)sender == Bottom)
            {
                string resourceID = "LoginPageDesign.images.restaurant.png";
                using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                {
                    var resourceBitmap = SKBitmap.Decode(stream);
                    if (resourceBitmap != null)
                    {
                        canvas.DrawCircle(0.42f * info.Width, (0.5f * info.Height) + 110, 20, paint);
                        canvas.DrawBitmap(resourceBitmap, (0.42f * info.Width) - 10, ((0.5f * info.Height) + 110) - 10);
                    }
                }
            }
        }
    }
}
