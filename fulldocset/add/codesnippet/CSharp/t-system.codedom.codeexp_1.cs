            // Creates an empty CodeExpressionCollection.
            CodeExpressionCollection collection = new CodeExpressionCollection();

            // Adds a CodeExpression to the collection.
            collection.Add( new CodePrimitiveExpression(true) );

            // Adds an array of CodeExpression objects to the collection.
            CodeExpression[] expressions = { new CodePrimitiveExpression(true), new CodePrimitiveExpression(true) };
            collection.AddRange( expressions );

            // Adds a collection of CodeExpression objects to the collection.
            CodeExpressionCollection expressionsCollection = new CodeExpressionCollection();
            expressionsCollection.Add( new CodePrimitiveExpression(true) );
            expressionsCollection.Add( new CodePrimitiveExpression(true) );
            collection.AddRange( expressionsCollection );

            // Tests for the presence of a CodeExpression in the 
            // collection, and retrieves its index if it is found.
            CodeExpression testComment = new CodePrimitiveExpression(true);
            int itemIndex = -1;
            if( collection.Contains( testComment ) )
                itemIndex = collection.IndexOf( testComment );

            // Copies the contents of the collection beginning at index 0 to the specified CodeExpression array.
            // 'expressions' is a CodeExpression array.
            collection.CopyTo( expressions, 0 );

            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;

            // Inserts a CodeExpression at index 0 of the collection.
            collection.Insert( 0, new CodePrimitiveExpression(true) );

            // Removes the specified CodeExpression from the collection.
            CodeExpression expression = new CodePrimitiveExpression(true);
            collection.Remove( expression );

            // Removes the CodeExpression at index 0.
            collection.RemoveAt(0);