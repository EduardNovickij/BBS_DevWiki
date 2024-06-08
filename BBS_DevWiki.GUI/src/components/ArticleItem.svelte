<script>
    import { deleteArticle } from '../stores/articles.js';
    export let article;

    const handleDelete = async () => {
        await deleteArticle(article.ID);
    };
</script>

<li class="article-item">
    <div class="article-header">
        <h3>{article.Title}</h3>
        <button class="delete-btn" on:click={handleDelete}>Delete</button>
    </div>
    <p>{article.Description}</p>
    <small>{new Date(article.ArticleDate).toLocaleDateString()}</small>
    <small class="article-type">{article.TypeName}</small>
</li>

<style>
    .article-item {
        padding: 1rem;
        border: 1px solid #ddd;
        border-radius: 8px;
        background-color: #fff;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        transition: box-shadow 0.3s ease;
    }

    .article-item:hover {
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    }

    .article-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    h3 {
        margin: 0;
        font-size: 1.25rem;
        color: #333;
    }

    .delete-btn {
        background-color: #dc3545;
        color: white;
        border: none;
        padding: 0.5rem 1rem;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .delete-btn:hover {
        background-color: #c82333;
    }

    p {
        margin: 0.5rem 0;
        color: #666;
    }

    small {
        display: block;
        margin-top: 0.5rem;
        color: #999;
    }

    .article-type {
        color: #007bff;
        font-weight: bold;
    }
</style>