プロジェクトのビルド結果を自動で特定のフォルダにコピーする機能を利用しています（xcopy）。

プロジェクト
→プロパティ
→ビルド
　→イベント

を参照してください。

サンプル：
xcopy /Y /E /I "$(TargetDir)*" "F:\Steam\steamapps\common\Elin\Package\Mod_RmFishing\"
