using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbeaufgabeQnips
{
    internal class JsonModel
    {
        public class Rootobject
        {
            public Allergens Allergens { get; set; }
            public Products Products { get; set; }
            public Row[] Rows { get; set; }
        }

        public class Allergens
        {
            [JsonProperty(PropertyName = "0_")]
            public _0_ _0_ { get; set; }
            [JsonProperty(PropertyName = "0_0")]
            public _0_0 _0_0 { get; set; }
            [JsonProperty(PropertyName = "0_2")]
            public _0_2 _0_2 { get; set; }
            [JsonProperty(PropertyName = "0_3")]
            public _0_3 _0_3 { get; set; }
            [JsonProperty(PropertyName = "0_1")]
            public _0_1 _0_1 { get; set; }
            [JsonProperty(PropertyName = "1_")]
            public _1_ _1_ { get; set; }
            [JsonProperty(PropertyName = "2_")]
            public _2_ _2_ { get; set; }
            [JsonProperty(PropertyName = "3_")]
            public _3_ _3_ { get; set; }
            [JsonProperty(PropertyName = "4_")]
            public _4_ _4_ { get; set; }
            [JsonProperty(PropertyName = "5_")]
            public _5_ _5_ { get; set; }
            [JsonProperty(PropertyName = "6_")]
            public _6_ _6_ { get; set; }
            [JsonProperty(PropertyName = "7_")]
            public _7_ _7_ { get; set; }
            [JsonProperty(PropertyName = "7_0")]
            public _7_0 _7_0 { get; set; }
            [JsonProperty(PropertyName = "7_1")]
            public _7_1 _7_1 { get; set; }
            [JsonProperty(PropertyName = "7_2")]
            public _7_2 _7_2 { get; set; }
            [JsonProperty(PropertyName = "7_3")]
            public _7_3 _7_3 { get; set; }
            [JsonProperty(PropertyName = "7_4")]
            public _7_4 _7_4 { get; set; }
            [JsonProperty(PropertyName = "7_5")]
            public _7_5 _7_5 { get; set; }
            [JsonProperty(PropertyName = "7_6")]
            public _7_6 _7_6 { get; set; }
            [JsonProperty(PropertyName = "7_7")]
            public _7_7 _7_7 { get; set; }
            [JsonProperty(PropertyName = "8_")]
            public _8_ _8_ { get; set; }
            [JsonProperty(PropertyName = "9_")]
            public _9_ _9_ { get; set; }
            [JsonProperty(PropertyName = "10_")]
            public _10_ _10_ { get; set; }
            [JsonProperty(PropertyName = "11_")]
            public _11_ _11_ { get; set; }
            [JsonProperty(PropertyName = "12_")]
            public _12_ _12_ { get; set; }
            [JsonProperty(PropertyName = "13_")]
            public _13_ _13_ { get; set; }
        }

        public class _0_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _0_0
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _0_2
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _0_3
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _0_1
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _1_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _2_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _3_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _4_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _5_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _6_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_0
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_1
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_2
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_3
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_4
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_5
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_6
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _7_7
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _8_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _9_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _10_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _11_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _12_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class _13_
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }

        public class Products
        {
            [JsonProperty(PropertyName = "4293205")]
            public _4293205 _4293205 { get; set; }

            [JsonProperty(PropertyName = "4293206")]
            public _4293206 _4293206 { get; set; }
            [JsonProperty(PropertyName = "4299359")]
            public _4299359 _4299359 { get; set; }
            [JsonProperty(PropertyName = "4299392")]
            public _4299392 _4299392 { get; set; }
            [JsonProperty(PropertyName = "4299401")]
            public _4299401 _4299401 { get; set; }
            [JsonProperty(PropertyName = "4299402")]
            public _4299402 _4299402 { get; set; }
            [JsonProperty(PropertyName = "4299404")]
            public _4299404 _4299404 { get; set; }
            [JsonProperty(PropertyName = "4299405")]
            public _4299405 _4299405 { get; set; }
            [JsonProperty(PropertyName = "4299407")]
            public _4299407 _4299407 { get; set; }
            [JsonProperty(PropertyName = "4299411")]
            public _4299411 _4299411 { get; set; }
            [JsonProperty(PropertyName = "4299413")]
            public _4299413 _4299413 { get; set; }
        }

        public class _4293205
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price Price { get; set; }
        }

        public class Price
        {
            public float Betrag { get; set; }
        }

        public class _4293206
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price1 Price { get; set; }
        }

        public class Price1
        {
            public float Betrag { get; set; }
        }

        public class _4299359
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price2 Price { get; set; }
        }

        public class Price2
        {
            public float Betrag { get; set; }
        }

        public class _4299392
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price3 Price { get; set; }
        }

        public class Price3
        {
            public float Betrag { get; set; }
        }

        public class _4299401
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price4 Price { get; set; }
        }

        public class Price4
        {
            public float Betrag { get; set; }
        }

        public class _4299402
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price5 Price { get; set; }
        }

        public class Price5
        {
            public float Betrag { get; set; }
        }

        public class _4299404
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price6 Price { get; set; }
        }

        public class Price6
        {
            public float Betrag { get; set; }
        }

        public class _4299405
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price7 Price { get; set; }
        }

        public class Price7
        {
            public float Betrag { get; set; }
        }

        public class _4299407
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price8 Price { get; set; }
        }

        public class Price8
        {
            public float Betrag { get; set; }
        }

        public class _4299411
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price9 Price { get; set; }
        }

        public class Price9
        {
            public float Betrag { get; set; }
        }

        public class _4299413
        {
            public string[] AllergenIds { get; set; }
            public int ProductId { get; set; }
            public string Name { get; set; }
            public Price10 Price { get; set; }
        }

        public class Price10
        {
            public float Betrag { get; set; }
        }

        public class Row
        {
            public string Name { get; set; }
            public Day[] Days { get; set; }
        }

        public class Day
        {
            public int Weekday { get; set; }
            public Productid[] ProductIds { get; set; }
        }

        public class Productid
        {
            public int ProductId { get; set; }
        }

    }
}
