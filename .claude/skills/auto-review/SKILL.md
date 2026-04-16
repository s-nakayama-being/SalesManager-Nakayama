---
name: auto-review
description: このリポジトリのオープンPRを巡回し、未レビューまたは前回レビュー以降にコードが更新されたPRに対して自動でコードレビューを投稿する。研修担当者向け自動レビュー機能。
---

このリポジトリのオープンPRをチェックし、「前回レビュー以降にコードが更新された」PRに対して自動でコードレビューを投稿してください。

GitHub操作には `gh` CLI を使用してください。リポジトリ指定は不要で、現在のディレクトリのリポジトリを対象とします。

## 手順

1. `gh pr list --state open --json number,title,headRefOid` でオープンPR一覧を取得
2. PRが0件なら「対象PRなし」と1行だけ報告して終了
3. owner と repo を `gh repo view --json owner,name -q '.owner.login + "/" + .name'` で取得
4. 各PRに対して以下を実行：
   a. 取得済みの `headRefOid` を現在の head SHA とする
   b. `gh api repos/{owner}/{repo}/pulls/{number}/reviews` で既存レビュー一覧を取得
   c. レビュー本文に `[auto-review for {現在のhead_sha}]` を含むものがあれば「同じSHAで既にレビュー済み」と判断しスキップ
   d. なければ `gh pr diff {number}` で差分を取得
   e. 差分を読み、コードレビューを作成
   f. レビュー本文の冒頭に必ず `[auto-review for {現在のhead_sha}]` のマーカー行を入れる
   g. `gh pr review {number} --comment --body "..."` で投稿

## レビュー作成方針

- **言語**: 日本語
- **文体**: 簡潔かつ具体的
- **構成**: 良い点と改善点を分けて記述
- **再レビュー時**: 前回レビューの修正対応状況にも言及
- **観点**: コードの正確性 / プロジェクト規約への準拠 / パフォーマンス / セキュリティ

## 完了報告

最後に以下の形式で1行サマリを出力してください：
`[auto-review] 投稿: N件 / スキップ: M件 / 対象なし: K件`
