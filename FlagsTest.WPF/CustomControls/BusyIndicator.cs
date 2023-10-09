using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FlagsTest.WPF.CustomControls
{
    public class BusyIndicator : Control
    {
        public Canvas Container { get; set; }
        public Storyboard StoryBoard { get; private set; }
        public DoubleAnimation RotateAnimation { get; set; }
        public Brush DotColor { get; private set; }

        public int DotCount
        {
            get { return System.Convert.ToInt32(GetValue(DotCountProperty)); }
            set { SetValue(DotCountProperty, value); }
        }

        public static readonly DependencyProperty DotCountProperty = DependencyProperty.Register("DotCount", typeof(int), typeof(BusyIndicator), new FrameworkPropertyMetadata(12, new FrameworkPropertyMetadataOptions()));

        public double DotRadius
        {
            get { return System.Convert.ToInt32(GetValue(DotRadiusProperty)); }
            set { SetValue(DotRadiusProperty, value); }
        }

        public static readonly DependencyProperty DotRadiusProperty = DependencyProperty.Register("DotRadius", typeof(double), typeof(BusyIndicator), new FrameworkPropertyMetadata(3.0, new PropertyChangedCallback(OnDotRadiusChanged)));

        public Brush DotColour
        {
            get { return (Brush)(GetValue(DotColourProperty)); }
            set { SetValue(DotColourProperty, value); }
        }

        public static readonly DependencyProperty DotColourProperty = DependencyProperty.Register("DotColour", typeof(Brush), typeof(BusyIndicator), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(27, 161, 226)), new FrameworkPropertyMetadataOptions()));


        public double Radius
        {
            get { return System.Convert.ToInt32(GetValue(DotRadiusProperty)); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(BusyIndicator), new FrameworkPropertyMetadata(14.0, new PropertyChangedCallback(OnRadiusChanged)));


        public bool IsSpinning
        {
            get { return System.Convert.ToBoolean(GetValue(IsSpinningProperty)); }
            set { SetValue(IsSpinningProperty, value); }
        }

        public static readonly DependencyProperty IsSpinningProperty = DependencyProperty.Register("IsSpinning", typeof(bool), typeof(BusyIndicator), new UIPropertyMetadata(true, OnIsSpinningChanged));



        public double Speed
        {
            get { return System.Convert.ToInt32(GetValue(SpeedProperty)); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly DependencyProperty SpeedProperty = DependencyProperty.Register("Speed", typeof(double), typeof(BusyIndicator), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(OnSpeedChanged)));


        public enum RotateDirection
        {
            CW = 1,
            CCW = 2
        }

        public RotateDirection Direction
        {
            get { return (RotateDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }


        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register("Direction", typeof(RotateDirection), typeof(BusyIndicator), new UIPropertyMetadata(RotateDirection.CW, OnDirectionChanged));



        public bool SymmetricalArrange
        {
            get { return System.Convert.ToBoolean(GetValue(SymmetricalArrangeProperty)); }
            set { SetValue(SymmetricalArrangeProperty, value); }
        }

        

        public static readonly DependencyProperty SymmetricalArrangeProperty = DependencyProperty.Register("SymmetricalArrange", typeof(bool), typeof(BusyIndicator), new UIPropertyMetadata(true, OnRadiusChanged));



        private Point CalculatePosition(double radian)
        {
            var x = 0 + this.Radius * Math.Cos(radian);
            var y = 0 + this.Radius * Math.Sin(radian);

            return new Point(x - this.DotRadius, y - this.DotRadius);
        }

        private void CreateAnimation()
        {
            this.RotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            this.RotateAnimation.SpeedRatio = this.Speed;
            if (this.Direction == RotateDirection.CCW)
                this.RotateAnimation.To *= -1;

            Storyboard.SetTarget(this.RotateAnimation, this.Container);
            Storyboard.SetTargetProperty(this.RotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            this.StoryBoard.Children.Add(this.RotateAnimation);
        }


        private Ellipse CreateEllipse(int counter)
        {
            var ellipse = new Ellipse();
            ellipse.Fill = this.DotColor;
            ellipse.Width = this.DotRadius * 2;
            ellipse.Height = this.DotRadius * 2;
            ellipse.Opacity = System.Convert.ToDouble(counter) / System.Convert.ToDouble(this.DotCount);

            this.SetEllipsePosition(ellipse, counter);

            return ellipse;
        }


        private void GenerateDots()
        {
            for (int i = 0; i <= this.DotCount - 1; i++)
            {
                var ellipse = this.CreateEllipse(i);

                this.Container.Children.Add(ellipse);
            }
        }

        private void InitialiseControl()
        {
            this.GenerateDots();
            this.CreateAnimation();

            this.ToggleSpinning(this.IsSpinning);
        }

        private void SetEllipsePosition(Ellipse ellipse, int ellipseCounter)
        {
            var maxCount = this.SymmetricalArrange ? this.DotCount : (2 * this.Radius * Math.PI) / (double)(2 * this.DotRadius + 2);

            var position = this.CalculatePosition(ellipseCounter * 2 * Math.PI / maxCount);
            Canvas.SetLeft(ellipse, position.X);
            Canvas.SetTop(ellipse, position.Y);
        }

        private void ToggleSpinning(bool value)
        {
            if (value)
                this.StoryBoard.Begin();
            else
                this.StoryBoard.Stop();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Container = this.GetTemplateChild("PART_Container") as Canvas;

            this.InitialiseControl();
        }



        private static void OnDirectionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var wheel = obj as BusyIndicator;
            if (wheel != null && e.NewValue != null && wheel.StoryBoard != null)
            {
                var prevState = wheel.IsSpinning;

                wheel.ToggleSpinning(false);
                wheel.RotateAnimation.To *= -1;
                wheel.ToggleSpinning(prevState);
            }
        }

        private static void OnDotCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var wheel = obj as BusyIndicator;
            if (wheel != null && wheel.Container != null && e.NewValue != null)
            {
                wheel.Container.Children.RemoveRange(0, System.Convert.ToInt32(e.OldValue));

                wheel.GenerateDots();
            }
        }



        private static void OnDotRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var wheel = obj as BusyIndicator;
            if (wheel != null && wheel.Container != null && e.NewValue != null)
            {
                var newRadius = System.Convert.ToDouble(e.NewValue);
                UpdateEllipses(wheel.Container.Children, (c, ellipse) =>
                {
                    ellipse.Width = newRadius * 2;
                    ellipse.Height = newRadius * 2;

                    wheel.SetEllipsePosition(ellipse, c);
                });
            }
        }


        private static void OnIsSpinningChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var wheel = obj as BusyIndicator;
            if (wheel != null && e.NewValue != null && wheel.StoryBoard != null)
                wheel.ToggleSpinning(System.Convert.ToBoolean(e.NewValue));
        }



        private static void OnRadiusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var wheel = obj as BusyIndicator;
            if (wheel != null && wheel.Container != null && e.NewValue != null)
                UpdateEllipses(wheel.Container.Children, (c, ellipse) => wheel.SetEllipsePosition(ellipse, c));
        }


        private static void OnSpeedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var wheel = obj as BusyIndicator;
            if (wheel != null && wheel.StoryBoard != null)
            {
                // don't ask
                wheel.StoryBoard.SetSpeedRatio(System.Convert.ToDouble(e.NewValue));
                wheel.RotateAnimation.SpeedRatio = System.Convert.ToDouble(e.NewValue);
            }
        }


        private static void UpdateEllipses(IEnumerable ellipses, Action<int, Ellipse> updateMethod)
        {
            if (updateMethod != null && ellipses != null)
            {
                int i = 1;
                foreach (var child in ellipses)
                {
                    var ellipse = child as Ellipse;
                    if (ellipse != null)
                        updateMethod(System.Math.Max(System.Threading.Interlocked.Increment(ref i), i - 1), ellipse);
                }
            }
        }




    }
}
