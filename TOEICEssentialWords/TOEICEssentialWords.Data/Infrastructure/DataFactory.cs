using System;

namespace TOEICEssentialWords.Data.Infrastructure
{
    public interface DataFactory : IDisposable
    {
        EssentialWordsContext Init();
    }
}