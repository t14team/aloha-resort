document.addEventListener('DOMContentLoaded', () => {
    const header = document.querySelector('.site-header');
    const fadeElements = document.querySelectorAll('.fade-in');
    const particlesContainer = document.getElementById('particles');

    if (header) {
        window.addEventListener('scroll', () => {
            header.classList.toggle('scrolled', window.scrollY > 50);
        });
    }

    const observer = new IntersectionObserver(
        (entries) => {
            entries.forEach((entry) => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('visible');
                }
            });
        },
        { threshold: 0.1, rootMargin: '0px 0px -50px 0px' }
    );

    fadeElements.forEach((el) => observer.observe(el));

    if (particlesContainer) {
        for (let i = 0; i < 30; i++) {
            const particle = document.createElement('div');
            particle.className = 'particle';
            particle.style.left = `${Math.random() * 100}%`;
            particle.style.top = `${Math.random() * 100}%`;
            particle.style.animationDelay = `${Math.random() * 8}s`;
            particle.style.animationDuration = `${6 + Math.random() * 6}s`;
            particlesContainer.appendChild(particle);
        }
    }

    const currentPath = window.location.pathname.toLowerCase();
    document.querySelectorAll('.nav-link').forEach((link) => {
        const href = link.getAttribute('href')?.toLowerCase() || '';
        if (href && currentPath.includes(href.replace('/', '')) && href !== '/') {
            link.classList.add('active');
        } else if (href === '/' && (currentPath === '/' || currentPath.endsWith('/home') || currentPath.endsWith('/home/index'))) {
            link.classList.add('active');
        }
    });
});
