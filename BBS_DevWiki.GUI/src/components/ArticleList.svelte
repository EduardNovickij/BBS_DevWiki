<script>
    import { onMount } from 'svelte';
    import { articles, articleTypes, fetchArticles, fetchArticleTypes } from '../stores/articles.js';
    import ArticleItem from './ArticleItem.svelte';

    let articlesWithTypes = [];

    onMount(async () => {
        await fetchArticles();
        await fetchArticleTypes();
    });

    $: articlesWithTypes = $articles.map(article => {
        const type = $articleTypes.find(t => t.ID === article.ArticleTypeID);
        return { ...article, TypeName: type ? type.Name : 'Unknown' };
    });
</script>

<ul class="article-list">
    {#each articlesWithTypes as article}
        <ArticleItem {article} />
    {/each}
</ul>

<style>
    .article-list {
        list-style: none;
        padding: 0;
        margin: 0;
        display: grid;
        gap: 1rem;
    }
</style>