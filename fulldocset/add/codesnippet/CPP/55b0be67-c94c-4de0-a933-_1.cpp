private:
   void WarpExample( PaintEventArgs^ e )
   {
      // Create a path and add a rectangle.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      RectangleF srcRect = RectangleF(0,0,100,200);
      myPath->AddRectangle( srcRect );

      // Draw the source path (rectangle)to the screen.
      e->Graphics->DrawPath( Pens::Black, myPath );

      // Create a destination for the warped rectangle.
      PointF point1 = PointF(200,200);
      PointF point2 = PointF(400,250);
      PointF point3 = PointF(220,400);
      array<PointF>^ destPoints = {point1,point2,point3};

      // Create a translation matrix.
      Matrix^ translateMatrix = gcnew Matrix;
      translateMatrix->Translate( 100, 0 );

      // Warp the source path (rectangle).
      myPath->Warp( destPoints, srcRect, translateMatrix, WarpMode::Perspective, 0.5f );

      // Draw the warped path (rectangle) to the screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Red ), myPath );
   }