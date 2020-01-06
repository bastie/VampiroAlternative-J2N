﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Xunit;

namespace J2N.Collections.Tests
{
    public class LinkedHashSet_Generic_Tests_string : LinkedHashSet_Generic_Tests<string>
    {
        protected override string CreateT(int seed)
        {
            int stringLength = seed % 10 + 5;
            Random rand = new Random(seed);
            byte[] bytes = new byte[stringLength];
            rand.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }

    public class LinkedHashSet_Generic_Tests_int : LinkedHashSet_Generic_Tests<int>
    {
        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override bool DefaultValueAllowed => true;
    }

    public class LinkedHashSet_Generic_Tests_int_With_Comparer_WrapStructural_Int : LinkedHashSet_Generic_Tests<int>
    {
        protected override IEqualityComparer<int> GetIEqualityComparer()
        {
            return new WrapStructural_Int();
        }

        protected override IComparer<int> GetIComparer()
        {
            return new WrapStructural_Int();
        }

        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override ISet<int> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<int>(new WrapStructural_Int());
        }
    }

    public class LinkedHashSet_Generic_Tests_int_With_Comparer_WrapStructural_SimpleInt : LinkedHashSet_Generic_Tests<SimpleInt>
    {
        protected override IEqualityComparer<SimpleInt> GetIEqualityComparer()
        {
            return new WrapStructural_SimpleInt();
        }

        protected override IComparer<SimpleInt> GetIComparer()
        {
            return new WrapStructural_SimpleInt();
        }

        protected override SimpleInt CreateT(int seed)
        {
            Random rand = new Random(seed);
            return new SimpleInt(rand.Next());
        }

        protected override ISet<SimpleInt> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<SimpleInt>(new WrapStructural_SimpleInt());
        }
    }

    //[OuterLoop]
    public class LinkedHashSet_Generic_Tests_EquatableBackwardsOrder : LinkedHashSet_Generic_Tests<EquatableBackwardsOrder>
    {
        protected override EquatableBackwardsOrder CreateT(int seed)
        {
            Random rand = new Random(seed);
            return new EquatableBackwardsOrder(rand.Next());
        }

        protected override ISet<EquatableBackwardsOrder> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<EquatableBackwardsOrder>();
        }
    }

    //[OuterLoop]
    public class LinkedHashSet_Generic_Tests_int_With_Comparer_SameAsDefaultComparer : LinkedHashSet_Generic_Tests<int>
    {
        protected override IEqualityComparer<int> GetIEqualityComparer()
        {
            return new Comparer_SameAsDefaultComparer();
        }

        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override ISet<int> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<int>(new Comparer_SameAsDefaultComparer());
        }
    }

    //[OuterLoop]
    public class LinkedHashSet_Generic_Tests_int_With_Comparer_HashCodeAlwaysReturnsZero : LinkedHashSet_Generic_Tests<int>
    {
        protected override IEqualityComparer<int> GetIEqualityComparer()
        {
            return new Comparer_HashCodeAlwaysReturnsZero();
        }

        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override ISet<int> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<int>(new Comparer_HashCodeAlwaysReturnsZero());
        }
    }

    //[OuterLoop]
    public class LinkedHashSet_Generic_Tests_int_With_Comparer_ModOfInt : LinkedHashSet_Generic_Tests<int>
    {
        protected override IEqualityComparer<int> GetIEqualityComparer()
        {
            return new Comparer_ModOfInt(15000);
        }

        protected override IComparer<int> GetIComparer()
        {
            return new Comparer_ModOfInt(15000);
        }

        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override ISet<int> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<int>(new Comparer_ModOfInt(15000));
        }
    }

    //[OuterLoop]
    public class LinkedHashSet_Generic_Tests_int_With_Comparer_AbsOfInt : LinkedHashSet_Generic_Tests<int>
    {
        protected override IEqualityComparer<int> GetIEqualityComparer()
        {
            return new Comparer_AbsOfInt();
        }

        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override ISet<int> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<int>(new Comparer_AbsOfInt());
        }
    }

    //[OuterLoop]
    public class LinkedHashSet_Generic_Tests_int_With_Comparer_BadIntEqualityComparer : LinkedHashSet_Generic_Tests<int>
    {
        protected override IEqualityComparer<int> GetIEqualityComparer()
        {
            return new BadIntEqualityComparer();
        }

        protected override int CreateT(int seed)
        {
            Random rand = new Random(seed);
            return rand.Next();
        }

        protected override ISet<int> GenericISetFactory()
        {
            return new J2N.Collections.Generic.LinkedHashSet<int>(new BadIntEqualityComparer());
        }
    }
}
