<script>
    import { onMount } from 'svelte';
    import { articles, articleTypes, fetchArticles, fetchArticleTypes } from '../stores/articles.js';
    import ArticleItem from './ArticleItem.svelte';

    let articlesWithTypes = [];

    onMount(async () => {
        await fetchArticles();
        await fetchArticleTypes();
    });

    //Add article type name to each article by using ArticleTypeID stored in Article object and ID stored in ArticleType object.
    $: articlesWithTypes = $articles.map(article => {
        const type = $articleTypes.find(t => t.ID === article.ArticleTypeID);
        return { ...article, TypeName: type ? type.Name : 'Unknown' };
    });
</script>

<ul class="article-list">
    {#each articlesWithTypes as article}
        <div>
            <ArticleItem {article} />
        </div>
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