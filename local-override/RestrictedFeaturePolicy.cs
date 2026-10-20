// 本 fork 的构建覆盖：关闭 Minecraft 下载 / 安装 / 修复 / 整合包安装的地区限制。
//
// 上游自 #3673 起在 Modules\Minecraft\RestrictedFeaturePolicy.cs 中实现了该限制。
// Directory.Build.targets 会把上游那份文件从编译项中移除，并改编译本文件。
//
// 两点刻意为之：
// 1. 本文件不引用 PCL.Core.App.Region，因此在上游相关 commit 尚未合并进本分支时也能编译通过；
// 2. 成员签名与上游保持一致，以后上游在别处新增 RestrictedFeaturePolicy.Check(...) 调用点时，
//    这些调用点会自动落到本实现上，无需再次修改。

namespace PCL;

/// <summary>
///     上游 RestrictedFeaturePolicy 的覆盖实现：永远判定为“不受限”。
/// </summary>
internal static class RestrictedFeaturePolicy
{
    internal static bool IsRestricted => false;

    internal static bool Check(string feature, bool showHint = true) => true;

    internal static void ThrowIfRestricted(string feature)
    {
    }
}
