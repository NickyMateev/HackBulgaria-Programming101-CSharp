using System;

namespace Vector
{
    class Vector
    {
        private readonly double[] coordinates;

        public Vector(params double[] coordinates)
        {
            this.coordinates = coordinates;
        }

        public Vector(Vector vect)
        {
            this.coordinates = vect.coordinates;
        }

        public double this[int index]
        {
            get
            {
                if (index >= coordinates.Length)
                {
                    throw new ArgumentException("ERROR: No such element exists.");
                }
                else
                    return this.coordinates[index];
            }
            set
            {
                if(index >= coordinates.Length)
                {
                    throw new ArgumentException("ERROR: No such element exists.");
                }
                else
                    this.coordinates[index] = value;
            }
        }

        public int Dimensionality
        {
            get
            {
                return this.coordinates.Length;
            }
        }

        public double GetLength()
        {
            double squareSum = 0;
            foreach (var coordinate in coordinates)
            {
                squareSum += Math.Pow(coordinate, 2);
            }
            return Math.Sqrt(squareSum);
        }

        public override string ToString()
        {
            return string.Format("Vector[{0}]", string.Join(", ", coordinates));
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector obj1 = this;
                Vector obj2 = (Vector)obj;

                if (obj1.Dimensionality == obj2.Dimensionality)
                {
                    for (int i = 0; i < obj1.Dimensionality; i++)
                    {
                        if (obj1.coordinates[i] != obj2.coordinates[i])
                            return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Vector vect1, Vector vect2)
        {
            return vect1.Equals(vect2);
        }

        public static bool operator !=(Vector vect1, Vector vect2)
        {
            return !(vect1.Equals(vect2));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var coordinate in coordinates)
                {
                    hash = hash * 23 + coordinate.GetHashCode();
                }
                return hash;
            }
        }

        public static Vector operator +(Vector vect1, Vector vect2)
        {
            if (vect1.Dimensionality == vect2.Dimensionality)
            {
                double[] coordinates = new double[vect1.Dimensionality];
                for (int i = 0; i < vect1.Dimensionality; i++)
                {
                    coordinates[i] = vect1.coordinates[i] + vect2.coordinates[i];
                }
                return new Vector(coordinates);
            }
            else
                throw new ArgumentException("ERROR: Cannot get sum of vectors with different dimensionality.");
        }

        public static Vector operator -(Vector vect1, Vector vect2)
        {
            if (vect1.Dimensionality == vect2.Dimensionality)
            {
                double[] coordinates = new double[vect1.Dimensionality];
                for (int i = 0; i < vect1.Dimensionality; i++)
                {
                    coordinates[i] = vect1.coordinates[i] - vect2.coordinates[i];
                }
                return new Vector(coordinates);
            }
            else
                throw new ArgumentException("ERROR: Cannot get difference of vectors with different dimensionality.");
        }

        public static Vector operator +(Vector vect, double scalar)
        {
            double[] coordinates = new double[vect.Dimensionality];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = vect.coordinates[i] + scalar;
            }
            return new Vector(coordinates);
        }

        public static Vector operator +(double scalar, Vector vect)
        {
            double[] coordinates = new double[vect.Dimensionality];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = scalar + vect.coordinates[i];
            }
            return new Vector(coordinates);
        }

        public static Vector operator -(Vector vect, double scalar)
        {
            double[] coordinates = new double[vect.Dimensionality];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = vect.coordinates[i] - scalar;
            }
            return new Vector(coordinates);
        }

        public static Vector operator *(Vector vect, double scalar)
        {
            double[] coordinates = new double[vect.Dimensionality];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = vect.coordinates[i] * scalar;
            }
            return new Vector(coordinates);
        }

        public static Vector operator *(double scalar, Vector vect)
        {
            double[] coordinates = new double[vect.Dimensionality];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = scalar * vect.coordinates[i];
            }
            return new Vector(coordinates);
        }

        public static Vector operator /(Vector vect, double scalar)
        {
            double[] coordinates = new double[vect.Dimensionality];
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = vect.coordinates[i] / scalar;
            }
            return new Vector(coordinates);
        }

        public static Vector operator *(Vector vect1, Vector vect2)
        {
            if (vect1.Dimensionality == vect2.Dimensionality)
            {
                double[] coordinates = new double[vect1.Dimensionality];
                for (int i = 0; i < vect1.Dimensionality; i++)
                {
                    coordinates[i] = vect1.coordinates[i] * vect2.coordinates[i];
                }
                return new Vector(coordinates);
            }
            else
                throw new ArgumentException("ERROR: Cannot get product of vectors with different dimensionality.");
        }
    }
}