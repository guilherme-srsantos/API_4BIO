using Bogus;
using System;

namespace API_4BIO.Data
{
    public static class ExtensionMethods
    {
        private static readonly Random _random = new ();
     
        private static int Rng()
        {
            return _random.Next(0, 9);
        }
        public static string Rg(this Person person)
        {
            return $"{Rng()}{Rng()}.{Rng()}{Rng()}{Rng()}.{Rng()}{Rng()}{Rng()}-{Rng()}";
        }

    }
}
