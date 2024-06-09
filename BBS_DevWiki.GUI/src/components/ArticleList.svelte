<script>
    import { onMount } from 'svelte';
    import { articles, articleTypes, fetchArticles, fetchArticleTypes } from '../stores/articles.js';
    import ArticleItem from './ArticleItem.svelte';

    //Filter values.
    let searchQuery = '';
    let selectedType = '';
    let startDate = '';
    let endDate = '';

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

    //Check whether article date is withing boundaries of start and end date.
    const isWithinDateRange = (articleDate, start, end) => {
        const date = new Date(articleDate);
        const startDate = start ? new Date(start) : null;
        const endDate = end ? new Date(end) : null;

        if (startDate) {
            startDate.setHours(0, 0, 0, 0);
        }
        if (endDate) {
            endDate.setHours(23, 59, 59, 999);
        }

        return (!startDate || date >= startDate) && (!endDate || date <= endDate);
    };

    //Filter out articles from articlesWithTypes list using input values.
    $: filteredArticles = articlesWithTypes.filter(article => {
        const matchesQuery = article.Title.includes(searchQuery) || article.Description.includes(searchQuery);

        const matchesType = selectedType ? article.ArticleTypeID === parseInt(selectedType) : true;

        const matchesDate = isWithinDateRange(article.ArticleDate, startDate, endDate);

        return matchesQuery && matchesType && matchesDate;
    });
</script>

<div class="filters">
    <input type="text" placeholder="Search by title or description" bind:value={searchQuery} class="search-input" maxlength="50" />
    <select bind:value={selectedType} class="filter-select">
        <option value="">All Types</option>
        {#each $articleTypes as type}
            <option value={type.ID}>{type.Name}</option>
        {/each}
    </select>
    <input type="date" bind:value={startDate} class="filter-date" />
    <input type="date" bind:value={endDate} class="filter-date" />
</div>

<ul class="article-list">
    {#each filteredArticles as article}
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

    .filters {
        display: flex;
        gap: 1rem;
        margin-bottom: 1rem;
    }

    .search-input, .filter-select, .filter-date {
        padding: 0.5rem;
        border: 1px solid #ddd;
        border-radius: 4px;
        font-size: 1rem;
        background-color: #fff;
    }

    .search-input:focus, .filter-select:focus, .filter-date:focus {
        border-color: #007bff;
        outline: none;
        box-shadow: 0 0 4px rgba(0, 123, 255, 0.25);
    }
</style>