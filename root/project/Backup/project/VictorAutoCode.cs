/*public void Movement(Reco id1, Reco id2)
        {
           Point LastCoord1 = id1.Coordinate;
           Point LastCoord2 = id2.Coordinate;
           
            Reco[] temp = WsClock.ToArray();
            for (int i = 0; i < WsClock.Count; i++)
            {
                temp[i].CoolDrawing(false,DrawingArea);
            }            

            lBitmapdrawingAreaOld = new Bitmap(panelDrawingArea.Width, panelDrawingArea.Height, panelDrawingArea.CreateGraphics());
           
  //пока координаты одного обьекта не станут координатами одного обьекта
            while ((id1.Coordinate != LastCoord2) && (id2.Coordinate != LastCoord1))
            {
                //System.Threading.Thread.Sleep(0);
                             
                //локально создаем копию  grapics
                Bitmap lBitmap = (Bitmap)lBitmapdrawingArea.Clone();
                Graphics lGraphics = Graphics.FromImage(lBitmap);
                
                //отрисовываем все те, что оп памяти
                for (int i = 0; i < WsClock.Count; i++)
                {
                    temp[i].CoolDrawing(false, lGraphics);
                }   
                //отрисовывем все те,что в виртуальной памяти
                for (int i = 0; i < VirtmemorySize; i++)
                {
                
                    {
                        if (VirtMemory[i] != null)
                        {
                            VirtMemory[i].CoolDrawing(false, lGraphics);
                        }
                    }
                }
                //рисуем движ обьекты
                id1.CoolDrawing(true, lGraphics);
                id2.CoolDrawing(true, lGraphics);

                lGraphics.Dispose();


                Graphics lGraphicsForm = panelDrawingArea.CreateGraphics();
                lGraphicsForm.DrawImage(lBitmap, new Point(0, 0));
                lGraphicsForm.Dispose();

                #region changing coordinate
                //двигать по отношению растояний
                if (id1.Coordinate.X > LastCoord2.X)
                {
                   id1.Coordinate = new Point(id1.Coordinate.X - 5, id1.Coordinate.Y);
                }
                if (id1.Coordinate.X < LastCoord2.X)
                {
                    id1.Coordinate = new Point(id1.Coordinate.X + 5,id1.Coordinate.Y);
                }
                if (id1.Coordinate.Y > LastCoord2.Y)
                {
                    id1.Coordinate = new Point(id1.Coordinate.X, id1.Coordinate.Y - 5);
                }
                if (id1.Coordinate.Y < LastCoord2.Y)
                {
                    id1.Coordinate = new Point(id1.Coordinate.X, id1.Coordinate.Y + 5);
                }
                //-----------------------------------------------------
                if (id2.Coordinate.X > LastCoord1.X)
                {
                    id2.Coordinate = new Point(id2.Coordinate.X - 5,id2.Coordinate.Y);
                }
                if (id2.Coordinate.X < LastCoord1.X)
                {
                    id2.Coordinate = new Point(id2.Coordinate.X + 5, id2.Coordinate.Y);
                }
                if (id2.Coordinate.Y > LastCoord1.Y)
                {
                    id2.Coordinate = new Point(id2.Coordinate.X, id2.Coordinate.Y - 5);
                }
                if (id2.Coordinate.Y < LastCoord1.Y)
                {
                    id2.Coordinate = new Point(id2.Coordinate.X, id2.Coordinate.Y + 5);
                }   
#endregion
            }            
        }  
        */  