<script>
    import ArticleList from './components/ArticleList.svelte';
    import ArticleForm from './components/ArticleForm.svelte';

    //Variable for switching active tab between ArticleList and ArticleForm.
    let activeTab = 'list';

    //Switch tab to list after new article is created.
    const handleFormSubmit = () => {
        activeTab = 'list';
    };
</script>

<main>
    <h1>Development Wiki</h1>
    <div class="tabs">
        <button 
            class="tab-button" 
            on:click={() => activeTab = 'list'} 
            class:selected={activeTab === 'list'}
        >
            Articles List
        </button>
        <button 
            class="tab-button" 
            on:click={() => activeTab = 'form'} 
            class:selected={activeTab === 'form'}
        >
            Add Article
        </button>
    </div>
    <div class="tab-content">
        <div class="tab-panel" class:visible={activeTab === 'list'}>
            <ArticleList />
        </div>
        <div class="tab-panel" class:visible={activeTab === 'form'}>
            <ArticleForm on:submit={handleFormSubmit} />
        </div>
    </div>
</main>

<style>
    main {
        padding: 1em;
        max-width: 800px;
        margin: 0 auto;
        font-family: Arial, sans-serif;
    }

    h1 {
        text-align: center;
        margin-bottom: 2rem;
        color: #007bff;
    }
    .tabs {
        display: flex;
        justify-content: center;
        margin-bottom: 1rem;
    }

    .tab-button {
        padding: 0.75rem 1.5rem;
        margin: 0 0.5rem;
        border: none;
        border-bottom: 2px solid transparent;
        background: none;
        font-size: 1rem;
        cursor: pointer;
        transition: all 0.3s;
    }

    .tab-button.selected {
        border-bottom: 2px solid #007bff;
        color: #007bff;
        font-weight: bold;
    }

    .tab-button:hover {
        color: #0056b3;
    }

    .tab-content {
        position: relative;
    }

    .tab-panel {
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        opacity: 0;
        pointer-events: none;
    }

    .tab-panel.visible {
        opacity: 1;
        pointer-events: all;
        transition: opacity 0.5s ease-in-out;
    }
</style>