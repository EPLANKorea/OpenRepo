using Eplan.EplApi.DataModel.MasterData;
using System;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public static class SymbolVariantHelper
    {
        public static SymbolVariant GetNext(SymbolVariant symbolVariant)
        {
            if (symbolVariant == null)
                throw new ArgumentNullException("symbolVariant");

            SymbolVariant[] symbolVariants = symbolVariant.Parent.Variants;

            int nextIndex = symbolVariant.VariantNr + 1;

            if (nextIndex >= symbolVariants.Length)
                nextIndex = 0;

            return symbolVariants[nextIndex];
        }
    }
}
